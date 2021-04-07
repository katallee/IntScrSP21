using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubePlayer : MonoBehaviour
{

    //reference to rigidbody
    Rigidbody rb;   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //set rigidbody drag to S.
        //freeze position y and z
        //freeze rotation x y z 
        rb.AddForce(Input.GetAxis("Horizontal") * 50, 0, Input.GetAxis("Vertical") * 50);
    }
}
