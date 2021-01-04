using UnityEngine.AI;
using UnityEngine;

public class SCR_PinkyAndInky : MonoBehaviour
{

    /// <Summary> This is the class used to define the movement of Pinky and Inky.
    /// <Description>
    /// This script gets a position within a certain area around the player as an attempt to ambush them.
    /// These scripts are called within the state machine. I have manually set the max and min amounts as the size of the playable area
    /// however they are editable within the inspector.
    /// </Description>

    private NavMeshAgent navMeshAgent;
    public Transform moveSpot;
    public float minX, maxX, minZ, maxZ;
    public Transform playerLocation;

    private void Start() {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void PinkyAndInkyStart()
    {
        moveSpot.position = new Vector3(Random.Range(playerLocation.localPosition.x - minX, playerLocation.localPosition.x + maxX), 0, Random.Range(playerLocation.localPosition.z - minZ, playerLocation.localPosition.z + maxZ));
    }

    public void PinkyAndInkyMove()
    {
        if(Vector3.Distance(transform.position, moveSpot.position) < 5f)
        {
            moveSpot.position = new Vector3(Random.Range(playerLocation.position.x + minX, playerLocation.position.x - maxX), 0, Random.Range(playerLocation.position.z + minZ, playerLocation.position.z - maxZ));
        }

        transform.rotation = Quaternion.Euler(0, 0, 0);
        navMeshAgent.SetDestination(moveSpot.position);
    }
}
