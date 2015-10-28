using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public bool isEnemy = true;
	public int health = 1;
	public GameObject deathParticles;

	// Use this for initialization
	void Start () {
		//deathParticles = Resources.Load<GameObject>("Lazy_Explosion");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.GetComponent<BulletBehavior>() != null)
		{
			int damage = other.gameObject.GetComponent<BulletBehavior>().damage;
			bool faction = other.gameObject.GetComponent<BulletBehavior>().isEnemy;
			if (faction != this.isEnemy) {
				TakeDamage(damage);
				other.gameObject.GetComponent<BulletBehavior>().Die();
			}
		}
	}

	void TakeDamage(int damage){
		health -= damage;
		if (health <= 0) {
			Die();
		}
	}

	void Die(){
		Instantiate(deathParticles, gameObject.transform.position, gameObject.transform.rotation);
		//Destroy containing gameObject
		Destroy(gameObject);
	}
}