using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SCR_Scatter : MonoBehaviour
{

    private NavMeshAgent agent;
    public Transform corner;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
    }
    public void GoHome(){
        agent.SetDestination(corner.position);
    }
}
