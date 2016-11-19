using UnityEngine;
using System.Collections;

public class DroneAI : MonoBehaviour {

	public GameObject scoreDisplay; //Refers to the gameobject on the HUD
	private Score scoreScript; //The script attached to the above object
	public GameObject ExplosionGo;
	public float speed = -15f;
	// Use this for initialization
	void Start () {
		scoreDisplay = GameObject.Find ("Score Display");
		scoreScript = scoreDisplay.GetComponent ("Score") as Score;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//get the enemy current position
		Vector2 position = transform.position;
		//compute the enemy new position
		position = new Vector2 (position.x - speed * Time.deltaTime, position.y); 

		//update the enemy position
		transform.position = position;

		//this is the bottom left point of the screen
		Vector2 min = Camera.main.ViewportToWorldPoint ( new Vector2 (0,0));

		//if the enemy went outside the screen on the bottom then destroy the enemy
		if (transform.position.y < min.x) 
		{
			Destroy (gameObject);
		}
			
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Ppro") 
		{
			
			scoreScript.addScore (100);
			Destroy (gameObject);
			PlayExplosion ();
		}
		if (other.tag == "Game Bounds") 
		{
			Destroy (gameObject);
		}
	}
	void PlayExplosion ()
	{
		GameObject explosion = (GameObject)Instantiate (ExplosionGo);
		explosion.transform.position = transform.position;
	}

	void OnBecameInvisible()
	{
		Destroy (this.gameObject);
	}

}
