using UnityEngine;
using System.Collections;

public class ParticleExpiration : MonoBehaviour {
	ParticleSystem particle;

	// Use this for initialization
	void Start () {
		particle = transform.GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!particle.IsAlive()) {
			Destroy(gameObject);		
		}
	}
}
