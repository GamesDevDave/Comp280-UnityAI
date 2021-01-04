using UnityEngine;
using UnityEngine.AI;

public class SCR_Scatter : MonoBehaviour
{

    /// <Summary> This is a script to make the ghosts scatter when the player picks up a powerpill.
    /// <Description>
    /// This script makes the ghosts return to their home points whenever the powerpill is picked up. The goal is to get away from the player
    /// however the player will always been near a corner when this occurs thus giving more balanced gameplay.
    /// </Description>

    private NavMeshAgent agent;
    public Transform corner;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
    }
    public void GoHome(){
        agent.SetDestination(corner.position);
    }
}
