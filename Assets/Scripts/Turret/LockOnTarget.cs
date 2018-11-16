using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOnTarget : MonoBehaviour
{

    public Vector3 direction;
    public GameObject enemy;

    public bool lockedOn = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(target);

        if (lockedOn)
        {
            if (enemy == null)
            {
                lockedOn = false;
            }
            else
            {
                direction = (enemy.transform.position - transform.position);
                Debug.DrawLine(transform.position, enemy.transform.position, Color.blue, 2, false);
                transform.right = direction;
            }
        }

        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            lockedOn = true;
            enemy = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            lockedOn = false;
        }
    }

}