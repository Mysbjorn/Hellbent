using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] string messageOnHover = null;
    bool pickedup = false;
    public MovementInput movement;

    public bool CanBeInteractedWith() { return true; }
    public void EndInteration() { }

       void OnTriggerEnter(Collider other)
        {
            if (pickedup == false && other.gameObject.CompareTag("Player"))
            {
            movement.havekey = true;
            pickedup = true;
            Destroy(gameObject);
            }
        }
       

    public string MessageOnDetection()
    {
        return messageOnHover;
    }
}
