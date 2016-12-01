using UnityEngine;
using System.Collections;

public class ArbiterAim : MonoBehaviour {

	float speed;
	Vector2 _direction;
	bool isReady;

	void Awake()
	{
		speed = 30f;
		isReady = false;
	}

	public void SetDirection(Vector2 direction)
	{
		_direction = direction.normalized;

		isReady = true;

	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if (isReady) 
		{
			 
			Vector2 position = transform.position;

			position += _direction * speed * Time.deltaTime;

			transform.position = position;
		}
	}

	void OnBecameInvisible()
	{
		Destroy (this.gameObject);
	}
}
