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


	protected virtual void ReceiveDamage(int damage) { }
	

}
