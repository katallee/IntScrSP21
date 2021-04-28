using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForPlayer : MonoBehaviour
{
    public Transform player;
    public bool canSeePlayer;

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(this.transform.position, transform.forward * 5);
        Debug.Log("Angle to player: " + Vector3.Angle(this.transform.position, player.position));
    }
}
