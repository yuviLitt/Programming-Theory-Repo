using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingThing : MonoBehaviour
{

	//These never change during game
	//config in editor
	[SerializeField] protected int meleeDamage;
	[SerializeField] protected float speed;
    [SerializeField] protected float yLim; //8 aprox.

    // ENCAPSULATION
    //not change during game
	public int p_meleeDamage{ get; private set; }
	public float p_speed{ get; private set; }


    //methods to override
    //move forward
    protected virtual void Move() {
        transform.Translate(Vector3.up * Time.deltaTime * p_speed);
    }

    //control that object is out of screen bounds
    protected virtual void PositionControl() {
        //it goes from top to bottom - FUT maybe other paths
        if (transform.position.y < -yLim
			|| transform.position.y > yLim){
            Destroy(gameObject);
        }
    }

    // ABSTRACTION
    //only time they are set
    protected void InitValues()
    {
        p_meleeDamage = meleeDamage;
        p_speed = speed;
    }


    protected virtual void Start(){
        //Debug.Log("start moving thing");
        InitValues();
	}

    void Update()
    {
        // ABSTRACTION
        //if (gameManager.isPlaying)
        //{

        //Manage movement
        Move();

        //Limit player to the screen
        PositionControl();
        //}

    }

}