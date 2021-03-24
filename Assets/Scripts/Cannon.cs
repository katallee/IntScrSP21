using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour, Threat
{

    [SerializeField]
    Transform bulletSpawn;

    bool handInView = false;

    void Start()
    {
        if(bulletSpawn == null) {
            bulletSpawn = this.transform.GetChild(0);
        }
    }

    public void Fire(Transform Hand)
    {
        Debug.Log("<color=red>Die!</color>");
        //TO DO 
        //if statement to test if hand of player controller is facing cannon.
        //if hand facing cannon bool handInView = true
        if(handInView) {                                           //if canfire is true
            GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            ball.transform.localScale = Vector3.one * 0.8f;
            ball.transform.position = bulletSpawn.position;
            ball.transform.Translate(transform.forward);    //move the ball forward by 1 meter

            Rigidbody rb = ball.AddComponent<Rigidbody>();
            rb.AddForce(transform.forward * 50, ForceMode.Impulse);
        }
    }
}
