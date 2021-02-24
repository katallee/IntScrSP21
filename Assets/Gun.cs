using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float bulletSpeed = 10f;     //couldn't get the code to work until I debugged and added f to 10
    public Rigidbody bullet;

    //this function will be called from the PlayerController.
    public void Pickup(Transform hand) {
        Debug.Log("I am running the Pickup() method.");
        this.gameObject.transform.SetParent(hand);             //make gun follow hand
        this.transform.localPosition = Vector3.zero;           //move gun to hand
        this.transform.localRotation = Quaternion.identity;    //make gun face forward same as hand
        this.GetComponent<Rigidbody>().isKinematic = true;     //make gun not fall
        this.GetComponent<Collider>().enabled = false;                                  //turn off gun's collider
        // other.GetComponent<RigidBody>().enabled = false;      //if you still getpushed around, add this
    }

    public void Use() {
        Debug.Log("<color=red>Pow!</color>");
        Rigidbody bulletClone = (Rigidbody) Instantiate(bullet, transform.position, transform.rotation);
        bulletClone.velocity = transform.forward * bulletSpeed;
        //code for public bulletSpeed, bullet, and bulletClone components found in Unity's community forum
        //https://answers.unity.com/questions/581576/simple-bullet-script.html
    }

    public void Drop() {
        Debug.Log("Dropping our item.");
        this.gameObject.transform.SetParent(null);  //make gun stop following hand
        this.GetComponent<Rigidbody>().isKinematic = false; //make gun fall
        this.transform.Translate(0, 0, 2);  //move the gun forward 2 meters
        this.GetComponent<Rigidbody>().AddForce(Vector3.forward * 10, ForceMode.Impulse);   //throw gun away with force
        this.GetComponent<Collider>().enabled = true;   //turn on gun's collider
    }
}


     
     
