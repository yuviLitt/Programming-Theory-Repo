using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class PlayerShip : Ship
{
	private float horizontalInput;
	private float verticalInput;

    //web gl screen limits
    //config from editor
    [SerializeField] private float xLim; // = 6.0f;
	[SerializeField] private float yLim; // = 3.5f;


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
    //move with arrows/asdf
    protected override void Move() {

		horizontalInput = Input.GetAxis("Horizontal");
		verticalInput = Input.GetAxis("Vertical");

		transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * base.p_speed);
		transform.Translate(Vector3.up * verticalInput * Time.deltaTime * base.p_speed);
	}

    //shoot with space bar
    protected override void Shoot(){

		if (Input.GetKeyDown(KeyCode.Space)){
			Vector3 projectileSpawnPosition = new Vector3(gameObject.transform.position.x,
				gameObject.transform.position.y,
				gameObject.transform.position.z + 3.0f);

			//Launch a projectile from the player
			Instantiate(base.p_originalShoot, projectileSpawnPosition, base.p_originalShoot.transform.rotation);
		}
	}

    //control that player doesn't leave the screen
    protected override void PositionControl(){

        //control limits for X
        if (transform.position.x > xLim){
            transform.position = new Vector3(xLim, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -xLim){
            transform.position = new Vector3(-xLim, transform.position.y, transform.position.z);
        }

        //control limits for Y
        if (transform.position.y > yLim){
            transform.position = new Vector3(transform.position.x, yLim, transform.position.z );
        }
        else if (transform.position.y < -yLim){
            transform.position = new Vector3(transform.position.x, -yLim, transform.position.z );
        }

    }

}
