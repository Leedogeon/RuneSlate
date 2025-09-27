using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossDeathCheck : StateMachineBehaviour
{
    GameObject Boss;
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
     
        Boss = animator.gameObject;
        
        if(Boss.GetComponent<BossScript>())
        {
            Boss.GetComponent<BossScript>().Death(6);
        }

    }
}
