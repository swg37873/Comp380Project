using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButton("Fire1"))
		{
			startOver();
		}
		Invoke ("startOver", 3);
	
	}

	void startOver()
	{
		SceneManager.LoadScene ("TitleMenu");
	}
}
