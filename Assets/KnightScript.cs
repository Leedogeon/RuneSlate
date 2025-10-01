using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightScript : MonoBehaviour
{
    Animator anim;
    public float hp = 10;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Death()
    {
        hp = 0;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<CapsuleCollider>().isTrigger = true;
        gameObject.tag = "Enemy";
        gameObject.layer = 0;
        anim.SetTrigger("IsDeath");
    }
}