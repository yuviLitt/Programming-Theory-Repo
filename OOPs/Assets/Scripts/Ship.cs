using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public abstract class Ship : MonoBehaviour
{

	//These never change during game
	//config in editor
	[SerializeField] private int maxLife;
	[SerializeField] private int maxShield;
	[SerializeField] private int meleeDamage;
	[SerializeField] private float speed;
	[SerializeField] private Sprite spriteShip;
	[SerializeField] private string nameShip;
	[SerializeField] private GameObject originalShoot;

	// ENCAPSULATION
	
	//not change during game
	//redundant?
	public int p_maxLife { get; private set; }
	public int p_maxShield{ get; private set; }
	public int p_meleeDamage{ get; private set; }
	public float p_speed{ get; private set; }
	public Sprite p_spriteShip{ get; private set; }
	public string p_nameShip{ get; private set; }
	public GameObject p_originalShoot{ get; private set; }


	//change during game
	//life
	private int m_life;
	public int p_life {
		get { return m_life; }
		set { m_life = value; }
	}

	//shield
	private int m_shield;
	public int p_shield
	{
		get { return m_shield; }
		set { m_shield = value; }
	}

	//methods to override
	protected abstract void Move();
	protected abstract void Shoot();
	protected abstract void PositionControl();

	//public int valueScore; //value of enemy 4 the score TO ENEMY

	private void Start(){
		InitValues();
		ResetStatsShip();

		//Debug.Log("Start Ship m_shield: " + m_shield);
		//Debug.Log("Start Ship m_life: " + m_life);
	}

	//only time they are set
	private void InitValues() {
		p_maxLife = maxLife;
		p_maxShield = maxShield;
		p_meleeDamage = meleeDamage;
		p_speed = speed;
		p_spriteShip = spriteShip;
		p_nameShip = nameShip;
		p_originalShoot = originalShoot;
	}

	public void ResetStatsShip(){
		p_shield = maxShield;
		p_life = maxLife;
	}

	//Manage COLLISIONS
	private void OnTriggerEnter(Collider other)
	{

		//Debug.Log("Trigger Enter: this: " + gameObject.tag + " /other " + other.gameObject.tag);

		//ship collisions with shoots
		if (other.gameObject.CompareTag("Projectil"))
		{

			Debug.Log("Ship " + gameObject.name + " was shot with Projectil");
			//ReceiveDamage(projectil.damage); //damage from other.gameObject to gameobject

		}

		//else if for bonuses - other.gameObject.CompareTag("Bonus") - FUT

		//melee collisions between ships
		else
		{
			Debug.Log("Melee collision: " + gameObject.tag + " /other " + other.gameObject.tag);
			//ReceiveDamage(shipOther.meleeDamage); //damage from other.gameObject to gameobject
		}

	
	}

	private void ReceiveDamage(int damage){
	}



}