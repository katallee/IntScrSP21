using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour, IItem
{

    [SerializeField]
    Light flashlight;

    public void Pickup(Transform hand) {
        Debug.Log("I am running the Pickup() method.");
        this.gameObject.transform.SetParent(hand);             //make item follow hand
        this.transform.localPosition = Vector3.zero;           //move item to hand
        this.transform.localRotation = Quaternion.identity;    //make item face forward same as hand
        this.GetComponent<Rigidbody>().isKinematic = true;     //make item not fall
        this.GetComponent<Collider>().enabled = false;         //turn off item's collider
        // other.GetComponent<RigidBody>().enabled = false;    //if you still getpushed around, add this
    }

    public void Use() {
        Debug.Log("Using out Light");
        flashlight.enabled = !flashlight.enabled;
    }

    public void Drop() {
        Debug.Log("Dropping our item.");
        this.gameObject.transform.SetParent(null);  //make item stop following hand
        this.GetComponent<Rigidbody>().isKinematic = false; //make item fall
        this.transform.Translate(0, 0, 2);  //move the item forward 2 meters
        this.GetComponent<Rigidbody>().AddForce(Vector3.forward * 10, ForceMode.Impulse);   //throw item away with force
        this.GetComponent<Collider>().enabled = true;   //turn on item's collider
    }
}
