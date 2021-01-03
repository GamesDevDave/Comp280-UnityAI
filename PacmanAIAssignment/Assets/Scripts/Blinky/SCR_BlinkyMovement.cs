using UnityEngine;
using UnityEngine.AI;

public class SCR_BlinkyMovement : MonoBehaviour
{

    [Tooltip("The spawn location of Blinky, is used whenever the player is killed.")]    
    public Transform spawnLocation;

    [Tooltip("A reference to the player.")]
    public GameObject target;

    [Tooltip("A reference to the NavMeshAgent on Blinky, this gives access to the methods within the NavMeshAgent class.")]
    private NavMeshAgent agent;

    void Start()
    {
        // This is used to assign the agent variable with the NavMeshAgent component on Blinky.
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        
    }

    public void Movement(){
        // Keeps the rotation of Blinky at 0 since there's not really a need to change it.
        transform.rotation = Quaternion.Euler(0,0,0);

        // Uses the NavMeshAgent function SetDestination to travel to the players location.
        agent.SetDestination(target.transform.position);
    }
}
