﻿using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {
	public float speed = 1f;
	public int damage = 1;
	public bool isEnemy = false;
	public GameObject deathParticles;
	private float lifespan;

	// Use this for initialization
	void Start () {
		lifespan = 10f;
	}
	
	// Update is called once per frame
	void Update () {
		lifespan -= Time.deltaTime;
		if(lifespan <= 0){
			Die();
		}

		float trans = Time.deltaTime * speed;
		transform.Translate(trans,0f,0f);
	}

	//Called by objects that have collided with this bullet
	public void Die(){
		if (deathParticles != null) {
			Instantiate (deathParticles, gameObject.transform.position, gameObject.transform.rotation);
		}
		Destroy (gameObject);
	}
}
