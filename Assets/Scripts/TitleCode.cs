using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleCode : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButton("Fire1"))
			{
				startGame();
			}
	}
	void startGame()
	{
		SceneManager.LoadScene ("MainGame");
	}
}
