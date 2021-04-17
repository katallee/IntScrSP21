using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCam : MonoBehaviour
{

    public Transform rayEmitter;

    [SerializeField]
    Transform bulletSpawn;

    private RaycastHit hit;
    private Renderer rend;
    
    void Start() {
        rend = GetComponent<Renderer>();
        if(bulletSpawn == null) {
            bulletSpawn = this.transform.GetChild(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(rayEmitter.position, transform.forward, out hit)) {
            if(hit.collider.CompareTag("Player")) {
                rend.material.color = Color.red;
                Debug.DrawRay(rayEmitter.position, transform.forward * 10, Color.red, 1);
                //shoot at player
                GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                ball.transform.localScale = Vector3.one * 0.5f;
                ball.transform.position = bulletSpawn.position;
                ball.transform.Translate(transform.forward);    //move the ball forward by 1 meter

                Rigidbody rb = ball.AddComponent<Rigidbody>();
                rb.AddForce(transform.forward * 50, ForceMode.Impulse);
            }
            else {
                rend.material.color = Color.green;
                Debug.DrawRay(rayEmitter.position, transform.forward * 10, Color.green, 1);
            }

            Debug.Log("I have hit " + hit.collider.name);
        }

        //Debug.DrawRay(rayEmitter.position, transform.forward * 10, Color.white, 1);
    }
}
