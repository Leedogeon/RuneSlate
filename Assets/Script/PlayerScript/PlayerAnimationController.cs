using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] Animator anim;
    PlayerInput input;
    bool IsAttack = false;
    private void Awake()
    {
        input = transform.parent.GetComponentInChildren<PlayerInput>();
        anim = GetComponentInParent<Animator>();
    }
    public void MoveDirection(Vector2 moveInput, bool isWalk)
    {
        if(moveInput.magnitude > .1f)
        {
            anim.SetBool("IsRunning", true);
            anim.SetBool("IsWalk", isWalk);
        }
        else
        {
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsWalk", false);
        }
    }
    public void Attack()
    {
        anim.SetTrigger("OneHandAttack");
    }
}
