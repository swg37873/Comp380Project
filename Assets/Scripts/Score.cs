using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public int currentScore = 0;
	void Start () {
		currentScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		GetComponent<GUIText> ().text = "Score:  " + currentScore;
	}

	public void addScore(int x)
	{
		currentScore += x;
		Update ();
	}
}
