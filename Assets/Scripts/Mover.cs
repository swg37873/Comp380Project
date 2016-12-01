using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;

	private AudioSource source;

	void Awake()
	{
		source = GetComponent<AudioSource> ();

	}

	void Start ()
	{
		

	}

	// Use this for initialization
	void Update () 
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2 (speed, GetComponent<Rigidbody2D>().velocity.y);

	}
		
	
	void OnTriggerEnter2D(Collider2D other)
	{
		//Debug.Log (other.name);
		Destroy (gameObject);
	}
	void OnBecameInvisible()
	{
		Destroy (this.gameObject);
	}
}
