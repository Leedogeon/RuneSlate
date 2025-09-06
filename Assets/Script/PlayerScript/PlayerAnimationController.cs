using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] Animator anim;
    PlayerInput input;
    Rigidbody rigid;
    bool IsAttack = false;
    private void Awake()
    {
        input = transform.parent.GetComponentInChildren<PlayerInput>();
        anim = GetComponentInParent<Animator>();
        rigid = GetComponentInParent<Rigidbody>();
    }

    private void Update()
    {
        if(rigid.velocity.magnitude > .1f)
        {
            anim.SetBool("IsRunning", true);
            if(rigid.velocity.magnitude < 3f)
                anim.SetBool("IsWalk", true);
            else
                anim.SetBool("IsWalk", false);
        }
        else
        {
            anim.SetBool("IsWalk", false);
            anim.SetBool("IsRunning", false);
        }
    }


    public void Attack(int Blend)
    {
        anim.SetFloat("Blend", Blend);
        anim.SetTrigger("OneHandAttack");
    }

    public void Dash()
    {
        anim.SetTrigger("Dodge");
    }
}
