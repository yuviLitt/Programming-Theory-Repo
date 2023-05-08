using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class EnemyShip : Ship
{
	// ENCAPSULATION
	[SerializeField] private int scoreValue;
	public int p_scoreValue { get; private set; }

	// POLYMORPHISM
	protected override void Start()
	{
		//Debug.Log("start enemy ship");
		base.Start();
		p_scoreValue = scoreValue;
	}

	protected override void ReceiveDamage(int damage)
	{
		p_life -= damage;
		if (p_life <= 0)
		{
			Debug.Log("Ship is done");
			//sum scoreValue for the player total score
			Destroy(gameObject);
		}
	}

	void Update()
	{
		
		//if (gameManager.isPlaying)
		//{

		//Manage movement
		Move();// ABSTRACTION

        //Limit player to the screen
        PositionControl();// ABSTRACTION
        //}

    }

	//Manage COLLISIONS
	private void OnTriggerEnter(Collider other)
	{
		//enemy collisions with shoots
		if (other.gameObject.CompareTag("Projectil"))
		{
			//Debug.Log("Enemy: " + gameObject.name + " was shot with Projectil");
			var projectil = other.gameObject.GetComponent<MovingThing>();
			//damage from other.gameObject to gameobject
			ReceiveDamage(projectil.p_meleeDamage); // ABSTRACTION
			Destroy(other.gameObject); //destroy shoot
		}

		//melee collisions between ships
		else if(other.gameObject.CompareTag("Player"))

		{
			//Debug.Log("Melee collision: " + gameObject.tag + " /other " + other.gameObject.tag);
			var otherShip = other.gameObject.GetComponent<PlayerShip>();
			//damage from other.gameObject to gameobject
			ReceiveDamage(otherShip.p_meleeDamage); // ABSTRACTION
		}

	}

}