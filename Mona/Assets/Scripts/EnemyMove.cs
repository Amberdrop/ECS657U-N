using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public GameObject Player;
    private NavMeshAgent nav;

    public float walkRadius;
    public float speed;

    
    private float distance;


    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();

        //if(nav != null)
        //{
        //    nav.speed = speed;
        //    nav.SetDestination(RandomNavMeshLocation());
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //for following player
        //nav.SetDestination(Player.transform.position);


        if(nav!=null && nav.remainingDistance<=nav.stoppingDistance)
        {
            nav.speed = speed;
            nav.SetDestination(RandomNavMeshLocation());
        }

    }

    public Vector3 RandomNavMeshLocation()
    {
        Vector3 finalPos = Vector3.zero;
        Vector3 randomPos = Random.insideUnitSphere * walkRadius;
        randomPos += transform.position;

        if (NavMesh.SamplePosition(randomPos, out NavMeshHit hit, walkRadius, 1))
        {
            finalPos = hit.position;
        }
        return finalPos;
    }
}

