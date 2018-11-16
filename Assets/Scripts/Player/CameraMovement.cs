using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float movementspeed = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Controlls();

    }

    private void Controlls()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(movementspeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-movementspeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, movementspeed, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -movementspeed, 0);
        }
    }
}
