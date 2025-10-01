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
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.BossHPUI.SetActive(false);
            Boss.GetComponent<BossScript>().anim.enabled = false;
            NPCScript nPCScript = FindObjectOfType<NPCScript>();
            if(nPCScript != null)
            {
                PlayerDataControll.NPC1CanTalk = true;
            }


        }

    }
}
