using UnityEngine;
using UnityEngine.AI;

public class SCR_ClydeMovement : MonoBehaviour
{

    /// <Summary> This is the movement of clyde. His goal is to basically just wonder around.
    /// <Description>
    /// Clydes characteristics are based off of the original pacman, he sort of just goes whereever he feels like going, I tried to implement this as closely as I could.
    /// Firstly I set a perimeter around the board, a random position within that perimeter is then found and used to move an empty game object. (moveSpot).
    /// Once Clyde is close to his target another position is set and he will then move to that.
    /// </Description>

    private NavMeshAgent navMeshAgent;
    public Transform moveSpot;
    public float minX, maxX, minZ, maxZ;

    private void Start() {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void ClydeStart()
    {
        moveSpot.position = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
    }

    public void MoveClyde()
    {
        if(Vector3.Distance(transform.position, moveSpot.position) < 5f)
        {
            moveSpot.position = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
        }

        transform.rotation = Quaternion.Euler(0, 0, 0);
        navMeshAgent.SetDestination(moveSpot.position);
    }
}
