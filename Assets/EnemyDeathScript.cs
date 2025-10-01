using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathScript : StateMachineBehaviour
{
    GameObject enemy;
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.gameObject;
    }
}
