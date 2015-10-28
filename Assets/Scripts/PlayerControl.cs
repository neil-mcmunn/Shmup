using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public float speed = 1f;

	private float xTranslation = 0f;
	private float yTranslation = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		xTranslation = 0f;
		yTranslation = 0f;

		if(Input.GetKey(KeyCode.UpArrow)){
			yTranslation += 1.0f;
		}
		if(Input.GetKey(KeyCode.DownArrow)) {
			yTranslation -= 1.0f;
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			xTranslation -= 1.0f;
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			xTranslation += 1.0f;
		}

		if(!Input.GetKey (KeyCode.LeftShift)){
			xTranslation *= speed;
			yTranslation *= speed;
		}else{
			xTranslation *= (speed/2);
			yTranslation *= (speed/2);
		}


		xTranslation *= Time.deltaTime;
		yTranslation *= Time.deltaTime;
		transform.Translate (xTranslation, yTranslation, 0f);
	}
}
