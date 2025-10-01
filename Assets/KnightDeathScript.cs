using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightDeathScript : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Animator>().enabled = false;
        //Destroy(animator.gameObject);
    }
}
