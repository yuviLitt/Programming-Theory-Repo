using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class EnemyShip : Ship
{
	[SerializeField] private int scoreValue;
	public int p_scoreValue { get; private set; }// ENCAPSULATION

	protected override void Start()// POLYMORPHISM
	{
		base.Start();
		p_scoreValue = scoreValue;
	}

	void Update()
	{
		if (uiUpdater.isPlaying)
		{
			//Manage movement
			Move();// ABSTRACTION

			//Limit player to the screen
			PositionControl();// ABSTRACTION
		}
	}


	protected override void ReceiveDamage(int damage)// POLYMORPHISM
	{
		p_life -= damage;
		if (p_life <= 0)
		{
			//sum scoreValue for the player total score, update ui
			uiUpdater.SumScore(p_scoreValue);
			uiUpdater.SumEnemies();

			/* 4DEMO */
			//Destroy(gameObject);
			RespawnEnemy();
		}
	}

	/* 4DEMO */
	private void RespawnEnemy()
	{
		float xSpawnRange = 6.0f;
		float ySpawnRange = 7.5f;

		Vector3 posRespawn = new Vector3(Random.Range(-xSpawnRange, xSpawnRange), ySpawnRange, 0);

		transform.position = posRespawn;
	}


	//Manage COLLISIONS
	private void OnTriggerEnter(Collider other)
	{
		//enemy collisions with shoots
		if (other.gameObject.CompareTag("Projectil"))
		{
			var projectil = other.gameObject.GetComponent<MovingThing>();
			ReceiveDamage(projectil.p_meleeDamage); // ABSTRACTION
			Destroy(other.gameObject); //destroy shoot
		}

		//melee collisions between ships
		else if(other.gameObject.CompareTag("Player"))
		{
			var otherShip = other.gameObject.GetComponent<PlayerShip>();
			ReceiveDamage(otherShip.p_meleeDamage); // ABSTRACTION
		}
	}
}