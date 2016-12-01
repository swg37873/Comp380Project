using UnityEngine;
using System.Collections;

public class ArbiterGun : MonoBehaviour {

	public float timer; 
	public float startTime;
	public GameObject ArbitorShot;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("FireEnemyBullet", startTime, timer);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FireEnemyBullet()
	{
		//get reference for players ship
		GameObject player = GameObject.Find ("player");

		if (player != null)//if player is not dead
		{
			//instantiate bullet
			GameObject bullet = (GameObject)Instantiate (ArbitorShot);
			//set intial position
			bullet.transform.position = transform.position;
			//find direction towards player
			Vector2 direction = player.transform.position - bullet.transform.position;
			//set bullet direction
			bullet.GetComponent<ArbiterAim>().SetDirection(direction);
		
		}
	}
}
