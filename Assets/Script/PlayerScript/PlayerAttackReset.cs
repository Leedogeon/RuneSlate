using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerAttackReset : StateMachineBehaviour
{
    [SerializeField] string triggerName;
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger(triggerName);
        GameObject player = PlayerManager.Instance.PlayerInstance;

        player.GetComponentInChildren<PlayerAttack>().IsAttack = false;
    }
}
