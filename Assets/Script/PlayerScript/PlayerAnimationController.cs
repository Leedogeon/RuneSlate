using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] Animator anim;
    PlayerInput input;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        anim = GetComponent<Animator>();
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

}
