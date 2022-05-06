using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Opponent : MonoBehaviour
{
    NavMeshAgent agent;
    void Start()
    {
       
        agent = GetComponent<NavMeshAgent>();
        agent.destination = GameObject.FindGameObjectWithTag("FinishLine").transform.position;
    }

}
