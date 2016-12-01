using UnityEngine;
using System.Collections;

public class ArbiterAi : MonoBehaviour {

	public GameObject ExplosionGo;

	float xdesired;
	Vector2 position;
	// Use this for initialization
	void Start () 
	{
		//get the enemy current position
		position = transform.position;
		//desired x position
		xdesired = position.x - 5.0f;
	}

	// Update is called once per frame
	void Update () 
	{
		
		if(xdesired < position.x) 
		{
			//compute the enemy new position
			//position = new Vector2 (position.x, position.y); 
			position.x -= 0.1f;
			//update the enemy position
			transform.position = position;
		}
		//this is the bottom left point of the screen
		Vector2 min = Camera.main.ViewportToWorldPoint ( new Vector2 (0,0));


	}


	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Ppro") 
		{
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
