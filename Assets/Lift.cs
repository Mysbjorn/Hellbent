using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public float speed = 10000;
    public bool canHold = true;
    public GameObject thingy;
    public Transform guide;
    public Rigidbody thingybody;

    private void Update()
    {
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!canHold)
                    Throw_drop();
                else
                    Pickup();
            }//mause If

            if (!canHold && thingy)
                thingy.transform.position = guide.position;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "iCanbePickedup!")
            if (!thingy) // if we don't have anything holding
                thingy = col.gameObject;
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "thingy")
        {
            if (canHold)
                thingy = null;
        }
    }

    private void Pickup()
    {
        thingy.GetComponent<Rigidbody>().isKinematic = true;

        if (!thingy)
            return;

        //We set the object parent to our guide empty object.
        thingy.transform.SetParent(guide);

        //Set gravity to false while holding it
        thingy.GetComponent<Rigidbody>().useGravity = false;

        //we apply the same rotation our main object (Camera) has.
        thingy.transform.localRotation = transform.rotation;
        //We re-position the ball on our guide object 
        thingy.transform.position = guide.position;

        canHold = false;
    }

    private void Throw_drop()
    {
        
        if (!thingy)
        {
        //sätt gravitation till true
        thingy.GetComponent<Rigidbody>().useGravity = true;
            // we don't have anything to do with our ball field anymore
            thingybody.AddForce(Vector3.forward, ForceMode.Impulse);
        thingy = null;
        //Apply velocity on throwing
        //guide.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;
      


        //Unparent our ball
        guide.GetChild(0).parent = null;
        canHold = true;

        }
            return;

    }
}
