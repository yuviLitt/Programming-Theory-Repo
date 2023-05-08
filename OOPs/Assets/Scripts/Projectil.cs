using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectil : MonoBehaviour
{

	[SerializeField] private int damage;
	[SerializeField] private float speed;

	public int p_damage { get; private set; }
	public float p_speed { get; private set; }

	// Start is called before the first frame update
	void Start()
{
		p_damage = damage;
		p_speed = speed;
	}

}