using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_BlinkyChase : StateMachineBehaviour
{

    /// <Summary> This is the script that is used within the animator in order to reference Blinkys movement.
    /// <Description>
    /// In the start function I get all of the referneces I need in order to work through the animator.
    /// In the update function I reference the movement script of blinky and call the movement function.
    /// It also checks if the power pill is active to ensure the animators parameters are updated.
    /// </Description>

    public SCR_BlinkyMovement movementScript;
    private GameObject managerReference;
    [SerializeField]
    private SCR_GameManager gameManager;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        managerReference = GameObject.FindGameObjectWithTag("Manager");
        gameManager = managerReference.GetComponent<SCR_GameManager>();
        movementScript = animator.GetComponent<SCR_BlinkyMovement>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        movementScript.Movement();

        if(gameManager.powerpillActive){
            animator.SetBool("powerPillActive", true);
        }
    }
}
