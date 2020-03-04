using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public MovementInput movement;

    public void OnTriggerEnter(Collider other)
    {
        if (movement.havekey != false && other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("You made it throught the locked door!");
        }

       
    }
}
