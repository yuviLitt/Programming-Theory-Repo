using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Ship : MovingThing
{
	//config in editor
	[SerializeField] private int maxLife;
	
	// ENCAPSULATION
	//not change during game
	public int p_maxLife { get; private set; }

	//change during game
	//life
	private int m_life;
	public int p_life
	{
		get { return m_life; }
		set { m_life = value; }
	}


	// POLYMORPHISM
	protected override void Start()
	{
		//Debug.Log("start ship");
		base.Start();
		p_maxLife = maxLife;
		p_life = maxLife;
	}

	
	//Manage COLLISIONS
	private void OnTriggerEnter(Collider other)
	{

		Debug.Log("Trigger Enter: this: " + gameObject.tag + " /other " + other.gameObject.tag);

		
		//ship collisions with shoots
		if (other.gameObject.CompareTag("Projectil") && gameObject.CompareTag("Enemy")) //sometimes player shoots itself
        {

			Debug.Log("Enemy: " + gameObject.name + " was shot with Projectil");

            // ABSTRACTION
            var projectil = other.gameObject.GetComponent<MovingThing>();
            //damage from other.gameObject to gameobject
            ReceiveDamage(projectil.p_meleeDamage);

            Destroy(other.gameObject); //destroy shoot
        }

		//else if for bonuses - other.gameObject.CompareTag("Bonus") - FUT

		//melee collisions between ships
		else
		{
			Debug.Log("Melee collision: " + gameObject.tag + " /other " + other.gameObject.tag);
            // ABSTRACTION
            var otherShip = other.gameObject.GetComponent<MovingThing>();
            //damage from other.gameObject to gameobject
            ReceiveDamage(otherShip.p_meleeDamage);
            //ReceiveDamage(shipOther.meleeDamage); //damage from other.gameObject to gameobject
        }
		

	
	}

	protected virtual void ReceiveDamage(int damage) { }
	

}
