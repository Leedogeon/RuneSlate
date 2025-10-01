using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerAttackReset : StateMachineBehaviour
{
    [SerializeField] string triggerName;
    [SerializeField] GameObject player;
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
/*        animator.ResetTrigger(triggerName);
        GameObject player = PlayerManager.Instance.PlayerInstance;
        PlayerAttack attack = player.GetComponentInChildren<PlayerAttack>();
        if (attack.IsAttack[0] || attack.IsAttack[1])
        {
            attack.IsAttack[0] = false;
            attack.IsAttack[1] = false;
        }*/
        player = animator.gameObject;
        player.GetComponentInChildren<PlayerAttack>().CanAttack = true;
        player.GetComponentInChildren<PlayerAttack>().IsAttack_ = false;

    }
}
