using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FallingPlatform : MonoBehaviour
{

    //serialize variables
    [SerializeField]
    float hangTime = 2f, resetTime = 4f, returnInterval = 1f;

    [SerializeField]
    AnimationCurve curve;

    [SerializeField]
    Color activeColor = Color.red;
    
    Rigidbody rb;
    Renderer rend;                  
    Vector3 startPosition;              //stores x, y, z position
    Quaternion startRotation;           //stores w,x,y,z, rotation
    Color startColor;                   //stores rgba color
    bool platformIsActive = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.isKinematic = true;  //freeze the platform
        startPosition = this.transform.position;    //set the initial position of the platform
        rend = this.GetComponent<Renderer>();
        startColor = rend.material.color;
        startRotation = this.transform.rotation;
    }

    //don't forget to add another box collider as a trigger
    //don't forget to tag the FPS Controller as "Player"
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player") && !platformIsActive) {
            StartCoroutine(Fall());
           
        }
    }

    IEnumerator Fall() {
        Debug.Log("Starting fall process");
        platformIsActive = true;
        StartCoroutine(LerpColor(startColor, activeColor, 0.2f));
        yield return new WaitForSeconds(hangTime);
        rb.isKinematic = false;
        
        yield return new WaitForSeconds(resetTime);
        Debug.Log("Resetting platform.");
        //reset the platform
        //this.transform.position = startPosition;
        rb.isKinematic = true;
        StartCoroutine(ReturnToStart());
    }

    IEnumerator ReturnToStart() {
        Vector3 endPosition = this.transform.position;   //this is the starting point of our Lerp
        Quaternion endRotation = this.transform.rotation;
        float elapsedTime = 0f;                         //how much time has passed since we started
    
        while(elapsedTime < returnInterval) {
            this.transform.position = Vector3.Lerp(endPosition, startPosition, curve.Evaluate(elapsedTime / returnInterval));
            this.transform.rotation = Quaternion.Lerp(endRotation, startRotation, curve.Evaluate(elapsedTime / returnInterval));
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        this.transform.position = startPosition;
        this.transform.rotation = startRotation;
        rend.material.color = startColor;
        StartCoroutine(LerpColor(startColor, activeColor, 0.2f));
        platformIsActive = false;
    }

    IEnumerator LerpColor(Color startColor, Color endColor, float interval) {
        float elapsedTime = 0f;
        while(elapsedTime < interval) {
            rend.material.color = Color.Lerp(startColor, endColor, curve.Evaluate(elapsedTime / interval));
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        rend.material.color = endColor;
    }
}
