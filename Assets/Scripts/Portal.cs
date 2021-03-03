using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour, IItem
{    
    public Rigidbody bullet;

    [SerializeField]
    Transform bulletSpawn;

    [SerializeField]
    GameObject player;
    
    bool canFire = true;
    bool hasBeenFired = false;
    IItem heldItem;

    void Start() {
        if(bulletSpawn == null) {
            bulletSpawn = this.transform.GetChild(0);
        }
    }

    //this function will be called from the PlayerController.
    public void Pickup(Transform hand) {
        Debug.Log("I am running the Pickup() method.");
        this.gameObject.transform.SetParent(hand);             //make portal gun follow hand
        this.transform.localPosition = Vector3.zero;           //move portal gun to hand
        this.transform.localRotation = Quaternion.identity;    //make portal gun face forward same as hand
        this.GetComponent<Rigidbody>().isKinematic = true;     //make portal gun not fall
        this.GetComponent<Collider>().enabled = false;         //turn off gun's collider
        // other.GetComponent<RigidBody>().enabled = false;    //if you still getpushed around, add this
    }

    public void Use() {
        if(hasBeenFired) {
            Teleport();
            Debug.Log("Using the portal");    
        } 
        else {
            GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            ball.transform.localScale = Vector3.one * 0.2f;
            ball.transform.position = bulletSpawn.position;
            ball.transform.Translate(transform.forward);    //move the ball forward by 1 meter
            Rigidbody rb = ball.AddComponent<Rigidbody>();
            rb.AddForce(transform.forward * 50, ForceMode.Impulse);
            }
        hasBeenFired = !hasBeenFired;       
        }
        
        

    public void Drop() {
         Debug.Log("Dropping our item.");
         this.gameObject.transform.SetParent(null);  //make gun stop following hand
         this.GetComponent<Rigidbody>().isKinematic = false; //make gun fall
         this.transform.Translate(0, 0, 2);  //move the gun forward 2 meters
         this.GetComponent<Rigidbody>().AddForce(Vector3.forward * 10, ForceMode.Impulse);   //throw gun away with force
         this.GetComponent<Collider>().enabled = true;   //turn on gun's collider
    }

    public void Teleport() {
        Debug.Log("Being called");

        player.transform.position = bullet.transform.position;
        player.transform.Translate(Vector3.up);
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(.1f);     //wait for 1 second
        canFire = true;                         //make canfire true again
    }
}

     
     
