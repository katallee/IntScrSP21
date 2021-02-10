
using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int coins = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
        Debug.Log("I have hit" + other.gameObject.name);
        
        if(other.gameObject.CompareTag("coin")) {
            Destroy(other.gameObject);
            coins +=1;
            // Destroy the coin
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.CompareTag("floor")) {
            other.gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("floor"))
        {
            other.gameObject.GetComponent<Renderer>().material.color = Color.black;

        }
    }
}
