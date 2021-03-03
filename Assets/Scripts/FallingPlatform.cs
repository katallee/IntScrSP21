using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FallingPlatform : MonoBehaviour
{

    //serialize variables
    [SerializeField]
    float hangTime = 2f, resetTime = 4f;

    //private variables
    Rigidbody rb;
    Renderer rend;                  
    Vector3 startPosition;              //stores x, y, z position
    Color startColor;                   //stores rgba color

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.isKinematic = true;  //freeze the platform
        startPosition = this.transform.position;    //set the initial position of the platform
        rend = this.GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    //don't forget to add another box collider as a trigger
    //don't forget to tag the FPS Controller as "Player"
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            StartCoroutine(Fall());
           
        }
    }

    IEnumerator Fall() {
        Debug.Log("Starting fall process");

        rend.material.color = Color.red;
        yield return new WaitForSeconds(hangTime);
        rb.isKinematic = false;
        
        yield return new WaitForSeconds(resetTime);
        Debug.Log("Resetting platform.");
        //reset the platform
        //this.transform.position = startPosition;
        StartCoroutine(ReturnToStart());

        rb.isKinematic = true;
        rend.material.color = startColor;
    }

    IEnumerator ReturnToStart() {
        Vector3 endPosition = this.transform.position;   //this is the starting point of our Lerp
        float elapsedTime = 0f;                         //how much time has passed since we started
    
        while(elapsedTime < 1) {
            this.transform.position = Vector3.Lerp(endPosition, startPosition, elapsedTime / 1);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        this.transform.position = startPosition;
        rend.material.color = startColor;
    }
}
