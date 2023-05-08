using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class EnemyShip : Ship
{
    // ENCAPSULATION
    [SerializeField] private int scoreValue;
    public int p_scoreValue { get; private set; }

    [SerializeField] private float yLim; //6.5


    private void Start(){
        //Debug.Log("Start enemy ship");
        p_scoreValue = scoreValue;
    }

    void Update()
	{

		//if (gameManager.isPlaying)
		//{

		//Manage shooting
		Shoot();

		//Manage movement
		Move();

		//Limit player to the screen
		PositionControl();
		//}

	}

	//POLYMORPHISM:
	//move forward
	protected override void Move(){
        transform.Translate(Vector3.up * Time.deltaTime * base.p_speed);
    }

	//shoot automatic (if it has shoot)
	protected override void Shoot(){

		if (base.p_originalShoot)
		{
			Vector3 projectileSpawnPosition = new Vector3(gameObject.transform.position.x,
				gameObject.transform.position.y + 4.0f,
				gameObject.transform.position.z);

			//Launch a projectile from the ship
			Instantiate(base.p_originalShoot, projectileSpawnPosition, base.p_originalShoot.transform.rotation);
		}
	}

	//control that enemy is not visible anymore
	protected override void PositionControl(){
		//it goes from top to bottom - FUT maybe other paths
		if (transform.position.y < -yLim){
			Destroy(gameObject);
		}

	}
}