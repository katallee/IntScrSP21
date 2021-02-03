using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int coins; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {

        Debug.Log("I have hit" + other.gameObject.name);
        if(other.gameObject.CompareTag("coin")) {
            Destroy(other.gameObject);
            coins +=1; 
        }
    }
}
