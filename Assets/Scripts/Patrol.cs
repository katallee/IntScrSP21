    // Patrol.cs
    using UnityEngine;
    using UnityEngine.AI;
    using System.Collections;


    public class Patrol : MonoBehaviour {

        public Transform[] points;
        public Transform goal;          //player
        private int destPoint = 0;
        private NavMeshAgent agent;


        void Start () {
            agent = GetComponent<NavMeshAgent>();

            // Disabling auto-braking allows for continuous movement
            // between points (ie, the agent doesn't slow down as it
            // approaches a destination point).
            agent.autoBraking = false;

            GotoNextPoint();
        }


        void GotoNextPoint() {
            // Returns if no points have been set up
            if (points.Length == 0)
                return;

            // Set the agent to go to the currently selected destination.
            agent.destination = points[destPoint].position;

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            destPoint = (destPoint + 1) % points.Length;
        }


        void Update () {
            // Choose the next destination point when the agent gets
            // close to the current one.

            Debug.Log("Distance to player: " + Vector3.Distance(this.transform.position, goal.transform.position));

            if(Vector3.Distance(this.transform.position, goal.transform.position) < 5) {
                agent.destination = goal.position;
            }
            else {
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();
            }
        //if the player is close
        //point a raycast at the player to see if the player is visible.
        //is the AI facing the player
        //if all 3 true, agent.destination = goal.position
        }

        
    }
