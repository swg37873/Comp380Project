using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour {

	public int movespeed;
	public int jumpHeight;
	Rigidbody2D rb2d;

	public GameObject ExplosionGo;
	public Transform shotSpawn;
	public GameObject shot1;
	public GameObject shot2;
	GameObject currentWeapon;

	public float fireRate;
	public float nextFire;

	public float health;
	public AudioClip hurt;
	public AudioClip explode;
	AudioSource hurtSource; //bad name I know.

	public GameObject statusDisplay; //Refers to the gameobject attached to the HUD
	private StatusText statusTextScript; //The script attached to the above object

	// Use this for initialization


	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		statusTextScript = statusDisplay.GetComponent ("StatusText") as StatusText;
		hurtSource = GetComponent<AudioSource> ();
		health = 3;
		currentWeapon = shot1;
	}
	
	// Update is called once per frame
	void Update () {
		
		rb2d.freezeRotation = true; //Ship should never rotate.

		if (Input.GetButton ("Boost"))
			movespeed = 20;
		else
			movespeed = 11;
		//Horizontal Movement
		Vector2 moveDir = new Vector2 (Input.GetAxisRaw ("Horizontal")* movespeed , rb2d.velocity.y);
		rb2d.velocity = moveDir;
		//Vertical Movement
		Vector2 moveDir2 = new Vector2 (rb2d.velocity.x,Input.GetAxisRaw ("Vertical")* movespeed );
		rb2d.velocity = moveDir2;

		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate (currentWeapon, shotSpawn.position, shotSpawn.rotation);
		}
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Epro") 
		{
			damageShip ();
		}
			
	}
	void OnCollisionEnter2D ( Collision2D other)
	{
		if (other.gameObject.tag == "Power")
		{
			//Debug.Log (other.name);
			currentWeapon = shot2;
		}
	}

	void damageShip()
	{
		
		// Debug.Log ("health: " + health);
		health--;

		if (health == 3) {
			hurtSource.PlayOneShot (hurt, 1f);
			statusTextScript.setGood ();
		}
		if (health == 2) {
			hurtSource.PlayOneShot (hurt, 1f);
			statusTextScript.setDamaged ();
		}
		if (health == 1) {
			hurtSource.PlayOneShot (hurt, 1f);
			statusTextScript.setCritical ();
		}
		if (health <= 0) {
			hurtSource.PlayOneShot (explode, 1f);
			shipExplode ();
		}
	}

	void PlayExplosion ()
	{
		GameObject explosion = (GameObject)Instantiate (ExplosionGo);
		explosion.transform.position = transform.position;
	}

	void shipExplode()
	{
		Destroy (gameObject);
		PlayExplosion ();
		gameOver();

	}

	void gameOver()
	{
		SceneManager.LoadScene ("GameOver");	
	}


}
