using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour
{
    //references to navmesh agent, player position and ground/player layers
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask isGround;
    public LayerMask isPlayer;

    //roaming current destination, is destination set and destination search range
    public Vector3 destination;
    bool destinationSet;
    public float destinationRange;

    //search range setting and player in range bool 
    public float searchRange;
    public bool playerInRange;


    void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();    
    }


    void SetRoaming()
    {
        //create random destination for agent within set destination range
        float setX = Random.Range(-destinationRange, destinationRange);
        float setZ = Random.Range(-destinationRange, destinationRange);

        //set destination for agent using generated destination range 
        destination = new Vector3(transform.position.x + setX, transform.position.y, transform.position.z + setZ);

        //check if destination is valid 
        bool groundCheck = Physics.Raycast(destination, -transform.up, 2f, isGround);

        //if valid destination then
        if (groundCheck)
        {
            //destination is set
            destinationSet = true;
        }
    }

    //roaming method for agent
    void Roaming()
    {
        //if destination not set call method to set destination
        if (!destinationSet)
        {
            SetRoaming();
        }

        //if destination is set then
        if (destinationSet)
        {
            //pass destinatation through to agent
            agent.SetDestination(destination);
        }

        //set range to search for new destination
        Vector3 destinationRange = transform.position - destination;
        bool destinationReached = destinationRange.magnitude < 1f;

        //if destination is reached then
        if (destinationReached)
        {
            //destination is no longer set
            destinationSet = false;
        }

    }

    //chasing state
    void Chasing()
    {
        //set the destination of the agent to that of the player position
        agent.SetDestination(player.position);
    }

    void Update()
    {
        //set search range for player objects
        playerInRange = Physics.CheckSphere(transform.position, searchRange, isPlayer);

        //if player not in range then
        if (!playerInRange)
        {
            //set to roaming state
            Roaming();
        }

        //if player is in range then
        if (playerInRange)
        {
            //set to chasing state
            Chasing();
        }
    }
}
