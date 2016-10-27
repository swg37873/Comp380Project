using UnityEngine;
using System.Collections;

public class EGB : MonoBehaviour {

	public float timer; 
	public float startTime;
	public Transform EshotSpawn;
	public GameObject shot;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("FireEnemyBullet", startTime, timer);
	}
	


	void FireEnemyBullet()
	{
		Instantiate (shot, EshotSpawn.position, EshotSpawn.rotation);
	}
}
