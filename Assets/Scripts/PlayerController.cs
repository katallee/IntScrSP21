using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int oxygenSupply = 0;
    bool crouch = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        crouching();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("I have hit " + other.gameObject.name + "!");
        if(other.gameObject.CompareTag("Pickup"))
        {
            Destroy(other.gameObject);
            oxygenSupply++;
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
