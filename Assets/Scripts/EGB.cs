using UnityEngine;
using System.Collections;

public class EGB : MonoBehaviour {

	public float timer; 
	public Transform EshotSpawn;
	public GameObject shot;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("FireEnemyBullet", 2.0f, timer);
	}
	


	void FireEnemyBullet()
	{
		Instantiate (shot, EshotSpawn.position, EshotSpawn.rotation);
	}
}
