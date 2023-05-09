using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class MovingThing : MonoBehaviour
{

	//These never change during game
	//config in editor
	[SerializeField] protected int meleeDamage;
	[SerializeField] protected float speed;
	[SerializeField] protected float yLim; //8 aprox.

	//not change during game
	public int p_meleeDamage{ get; private set; }// ENCAPSULATION
	public float p_speed{ get; private set; }// ENCAPSULATION

	protected UIStatsController uiUpdater;

	protected virtual void Start() // POLYMORPHISM
	{
		InitValues();

		//to update ui and game
		uiUpdater = GameObject.FindGameObjectWithTag("Stats").GetComponent<UIStatsController>();
	}

	void Update()
	{
		if (uiUpdater.isPlaying)
		{
			//Manage movement
			Move(); // ABSTRACTION

			//Limit player to the screen
			PositionControl(); // ABSTRACTION
		}
	}


	//methods to override
	//move forward
	protected virtual void Move()// POLYMORPHISM
	{
		transform.Translate(Vector3.up * Time.deltaTime * p_speed);
	}

	//control that object is out of screen bounds
	protected virtual void PositionControl()// POLYMORPHISM
	{
		//it goes from top to bottom - FUT maybe other paths
		if (transform.position.y < -yLim || transform.position.y > yLim){
			Destroy(gameObject);
		}
	}

	
	//only time they are set
	private void InitValues()// ABSTRACTION
	{
		p_meleeDamage = meleeDamage;
		p_speed = speed;
	}

}