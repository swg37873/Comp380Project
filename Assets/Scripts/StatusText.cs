using UnityEngine;
using System.Collections;

public class StatusText : MonoBehaviour {
	public Sprite Good;
	public Sprite Damaged;
	public Sprite Critical;

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = Good;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setGood(){
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = Good;
	}
	public void setDamaged(){
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = Damaged;
	}
	public void setCritical(){
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = Critical;
	}
}
