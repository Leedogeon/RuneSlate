using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackEnd : StateMachineBehaviour
{
    GameObject Enemy;
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        Enemy = animator.gameObject;

        Enemy.GetComponent<Enemy>().CanAttack = true;
        Enemy.GetComponent<Enemy>().isAttack = false;


    }
}
