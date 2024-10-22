using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements.Experimental;
namespace Enemy
{
    public class EnemyScript : MonoBehaviour
    {
        //navmesh stuff
        public Transform[] points;
        public NavMeshAgent nav;
        public int destPoint;
        // variables holding the different player states

        public Patroling patroling;
        public ChasingState chasing;

        public StateMachine sm;
        public bool isGrounded;

        //player
        public Transform player;
        public LayerMask playerLayer;

        //ranges for sight and spotting
        public float sightRange, spottingRange;
        public bool playerInSightRange, playerInSpottingRange;

        //Simple ground check
        private void OnCollisionStay2D(Collision2D collision)
        {
            isGrounded = true;
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            isGrounded = false;
        }

        // Start is called before the first frame update
        void Start()
        {
           
            sm = gameObject.AddComponent<StateMachine>();
            nav = GetComponent<NavMeshAgent>();
            // add new states here
            patroling = new Patroling(this, sm);
            chasing = new ChasingState(this, sm);
        
            // initialise the statemachine with the default state
            sm.Init(patroling);
        }

        // Update is called once per frame
        public void Update()
        {
            sm.CurrentState.LogicUpdate();
            //Makes the detection sphere
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
            playerInSpottingRange = Physics.CheckSphere(transform.position, spottingRange, playerLayer);
            //output debug info to the canvas
            string s;
            s = string.Format("last state={0}\ncurrent state={1}", sm.LastState, sm.CurrentState);
            Console.WriteLine(s);
        }



        void FixedUpdate()
        {
            sm.CurrentState.PhysicsUpdate();
        }



        public void CheckForChase()
        {
            //Changes the state if the player is within spoting distance
            if (playerInSpottingRange == true) 
            {
                sm.ChangeState(chasing);
            }

        }


        public void CheckForPatrol()
        {
            //Changes back to patroling when the playe leaves the sight range
            if (playerInSightRange == false) 
            {
                sm.ChangeState(patroling);
            }

        }
        
        private void OnDrawGizmosSelected()
        {
            //draws the spheres so i can see them in the Unity editor 
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position, sightRange);
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, spottingRange);
        }
    }
}


