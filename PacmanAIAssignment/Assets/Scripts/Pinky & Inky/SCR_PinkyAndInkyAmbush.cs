using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PinkyAndInkyAmbush : StateMachineBehaviour
{

    /// <Summary> This is the script that is used within the animator in order to allow the state machine to interact with the movement of Pinky and Inky.
    /// <Description>
    /// In the start function I get all of the referneces I need in order to work through the animator.
    /// In the update function I reference the movement script of Pinky and Inky movement and call the movement function.
    /// It also checks if the power pill is active to ensure the animators parameters are updated.
    /// </Description>

    public SCR_PinkyAndInky movementScript;
    private GameObject managerReference;
    [SerializeField]
    private SCR_GameManager gameManager;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        managerReference = GameObject.FindGameObjectWithTag("Manager");
        gameManager = managerReference.GetComponent<SCR_GameManager>();
        movementScript = animator.GetComponent<SCR_PinkyAndInky>();

        movementScript.PinkyAndInkyStart();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        movementScript.PinkyAndInkyMove();

        if(gameManager.powerpillActive){
            animator.SetBool("powerPillActive", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}