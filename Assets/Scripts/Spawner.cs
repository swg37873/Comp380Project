using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject Enemy1;
	public GameObject Enemy2;
	public GameObject Enemy3;
	public GameObject Enemy4;
	GameObject currentEnemy;

	public float maxSpawnRateInSeconds = 5f;
	// Use this for initialization
	void Start () {
		Invoke ("SpawnEnemy", maxSpawnRateInSeconds);

		//increase spawn rate every 30 seconds
		InvokeRepeating ("IncreaseSpawn", 0f, 30f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SpawnEnemy()
	{
		//bottom left of screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
		//top right of screen
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

		//make a dude
		GameObject anEnemy = (GameObject)Instantiate(Enemy1);
		anEnemy.transform.position = new Vector2 (max.x, Random.Range(min.y, max.y));

		//schedule when to spawn next enemy
		ScheduleNextEnemy();
	}

	void ScheduleNextEnemy()
	{
		float spawnInSeconds;

		if (maxSpawnRateInSeconds > 1f) {
			//pick a number betwen 1 and maxspawn rate
			spawnInSeconds = Random.Range (1f, maxSpawnRateInSeconds);

		} 
		else
			spawnInSeconds = 1f;
		Invoke ("SpawnEnemy", spawnInSeconds);

	}

	//funnction to increase the difficulty of the game
	void IncreaseSpawn()
	{
		if (maxSpawnRateInSeconds > 1f)
			maxSpawnRateInSeconds--;
		if (maxSpawnRateInSeconds == 1f)
			CancelInvoke ("IncreaseSpawn");

	}
}
