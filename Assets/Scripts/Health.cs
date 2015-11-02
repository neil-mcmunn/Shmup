using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public bool isEnemy = true;
	public int health = 1;
	public GameObject deathParticles;
	private EnemyScore score;

	// Use this for initialization
	void Start () {
		score = GetComponent<EnemyScore>();
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
		if (deathParticles != null) {
			Instantiate (deathParticles, this.gameObject.transform.position, this.gameObject.transform.rotation);
		}
		if (score != null) {
			score.givePoints();
		}
		Destroy(gameObject);
	}
}