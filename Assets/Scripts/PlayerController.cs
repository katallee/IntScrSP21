using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int oxygenSupply = 0;
    bool crouch = false;
    public int coins = 0;

    
    //variables that should go at the top
    [SerializeField]
    Transform hand; //this is a hand positioned Empty child of Camera
    
    IItem heldItem;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) {
            if(heldItem != null) { 
                heldItem.Use();
            } else {
                Debug.Log("We aren't holding anything.");
            }
        }

        if(Input.GetKeyDown(KeyCode.Q)) {
            if(heldItem != null) {
                heldItem.Drop();
                heldItem = null;
            } else {
                Debug.Log("We aren't holding anything.");
            }
        }

        crouching();


    }


    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("I have hit " + other.gameObject.name + "!");
         Debug.Log("I have hit " + other.gameObject.name);
        if(other.gameObject.CompareTag("Coin")) {
            //Destroy the coin
            Destroy(other.gameObject);
            coins += 1;
            Debug.Log("I have " + coins + " coins.");
        }

        if(other.gameObject.CompareTag("Item")) {
            Debug.Log("I'm trying to pickup an item.");
            //other.GetComponent<Gun>().Pickup(hand);
            if(heldItem != null) {
                return;
            }
            heldItem = other.GetComponent<IItem>();
            heldItem.Pickup(hand);
        }

        if(other.gameObject.CompareTag("Pickup"))
        {
            Destroy(other.gameObject);
            oxygenSupply++;
        }

        Debug.Log("I have hit" + other.gameObject.name);
        
        if(other.gameObject.CompareTag("Coin")) {
            Destroy(other.gameObject);
            coins +=1;
            // Destroy the coin
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.CompareTag("Floor")) {
            other.gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            other.gameObject.GetComponent<Renderer>().material.color = Color.black;

        }
    }

    void crouching()
    {
        if (Input.GetKeyDown(KeyCode.C) && crouch == false)
        {
            transform.localScale = new Vector3(1, .5f, 1);
            crouch = true;
        }
        else if (Input.GetKeyDown(KeyCode.C) && crouch == true)
        {
            transform.localScale = new Vector3(1, 1, 1);
            crouch = false;
        }
    }
}
