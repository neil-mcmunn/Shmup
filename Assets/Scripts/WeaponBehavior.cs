using UnityEngine;
using System.Collections;

//Simple weapon that instantiates a prefab while the shot button is held
public class WeaponBehavior : MonoBehaviour {
	public GameObject shot_type;
	public float firingInterval = 0.05f;
	private float timePassed = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (KeyCode.Z)) {
			timePassed += Time.deltaTime;
			if(timePassed >= 0){
				timePassed -= firingInterval;
				Fire();
			}
		}else{
			timePassed = 0f;
		}
	}

	void Fire(){
		Vector3 shotPosition = gameObject.transform.position;
		Quaternion shotRotation = gameObject.transform.rotation;
		Instantiate (shot_type, shotPosition, shotRotation);
	}
}
