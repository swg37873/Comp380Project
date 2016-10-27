using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour {

	public int movespeed;
	public int jumpHeight;
	Rigidbody2D rb2d;

	public GameObject ExplosionGo;
	public Transform shotSpawn;
	public GameObject shot;

	public float fireRate;
	public float nextFire;
	// Use this for initialization


	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
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
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);

		}


		
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Epro") 
		{

			Destroy (gameObject);
			PlayExplosion ();
			gameOver();

		}
	}
	void PlayExplosion ()
	{
		GameObject explosion = (GameObject)Instantiate (ExplosionGo);
		explosion.transform.position = transform.position;
	}
	void gameOver()
	{
		SceneManager.LoadScene ("GameOver");	
	}
}
