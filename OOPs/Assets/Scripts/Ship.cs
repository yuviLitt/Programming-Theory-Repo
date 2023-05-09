using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Ship : MovingThing
{
	//config in editor
	[SerializeField] private int maxLife;
	
	//not change during game
	public int p_maxLife { get; private set; }// ENCAPSULATION

	//change during game
	private int m_life;// ENCAPSULATION
	public int p_life
	{
		get { return m_life; }
		set { m_life = value; }
	}

	protected override void Start()// POLYMORPHISM
	{
		base.Start();
		p_maxLife = maxLife;
		p_life = maxLife;
	}

	protected virtual void ReceiveDamage(int damage) { }// POLYMORPHISM

}
