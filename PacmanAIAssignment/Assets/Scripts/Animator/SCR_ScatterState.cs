using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_ScatterState : StateMachineBehaviour
{

    public SCR_Scatter scatterScript;
    private GameObject managerReference;
    [SerializeField]
    private SCR_GameManager gameManager;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        scatterScript = animator.GetComponent<SCR_Scatter>();
        managerReference = GameObject.FindGameObjectWithTag("Manager");
        gameManager = managerReference.GetComponent<SCR_GameManager>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        scatterScript.GoHome();
        
        if(gameManager.powerpillActive != true){
            animator.SetBool("powerPillActive", false);
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
