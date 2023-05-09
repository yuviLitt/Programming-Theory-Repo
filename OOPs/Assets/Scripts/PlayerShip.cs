using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class PlayerShip : Ship
{
	private float horizontalInput;
	private float verticalInput;

	//config from editor
	[SerializeField] private GameObject originalShoot;
	[SerializeField] private float xLim; //web gl screen limits
									   
	public GameObject p_originalShoot { get; private set; }// ENCAPSULATION

	protected override void Start()// POLYMORPHISM
	{
		base.Start();
		p_originalShoot = originalShoot;

		//init stats
		uiUpdater.SetLife(p_maxLife);// ABSTRACTION
	}

	void Update()
	{
		if (uiUpdater.isPlaying){

			//Manage shooting
			Shoot(); // ABSTRACTION

			//Manage movement
			Move();// ABSTRACTION

			//Limit player to the screen
			PositionControl();// ABSTRACTION
		}
	}

	//shoot with space bar
	private void Shoot()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Vector3 projectileSpawnPosition = new Vector3(gameObject.transform.position.x,
				gameObject.transform.position.y + 2.0f,
				gameObject.transform.position.z);

			//Launch a projectile from the player
			Instantiate(p_originalShoot, projectileSpawnPosition, gameObject.transform.rotation);
		}
	}

	//move with arrows/asdf
	protected override void Move()// POLYMORPHISM
	{
		horizontalInput = Input.GetAxis("Horizontal");
		verticalInput = Input.GetAxis("Vertical");

		transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * base.p_speed);
		transform.Translate(Vector3.up * verticalInput * Time.deltaTime * base.p_speed);
	}


	//control that player doesn't leave the screen
	protected override void PositionControl()// POLYMORPHISM
	{
		//control limits for X
		if (transform.position.x > xLim)
		{
			transform.position = new Vector3(xLim, transform.position.y, transform.position.z);
		}
		else if (transform.position.x < -xLim)
		{
			transform.position = new Vector3(-xLim, transform.position.y, transform.position.z);
		}

		//control limits for Y
		if (transform.position.y > yLim)
		{
			transform.position = new Vector3(transform.position.x, yLim, transform.position.z);
		}
		else if (transform.position.y < -yLim)
		{
			transform.position = new Vector3(transform.position.x, -yLim, transform.position.z);
		}
	}

	protected override void ReceiveDamage(int damage) // POLYMORPHISM
	{
		p_life -= damage;
		//update life in ui
		uiUpdater.SetLife(p_life);// ABSTRACTION

		if (p_life <= 0)
		{
			Debug.Log("GAME OVER");
			Destroy(gameObject, 1);
			//finish demo
			uiUpdater.SetGameOver();// ABSTRACTION
		}
	}

	//Manage COLLISIONS
	private void OnTriggerEnter(Collider other)
	{
		//melee collisions between ships
		if (other.gameObject.CompareTag("Enemy")){

			var otherShip = other.gameObject.GetComponent<EnemyShip>();
			ReceiveDamage(otherShip.p_meleeDamage); // ABSTRACTION
		}

	}

}