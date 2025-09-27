using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_TutorialBoss : Enemy
{
    public bool CanAttack_B = false;
    private void Awake()
    {
        maxHp = 100;
        Hp = 100;
    }

    public override void Death(int index)
    {
        base.Death(6);
    }

    protected override void FixedUpdate()
    {
        if (!CanAttack_B) return;
        base.FixedUpdate();
    }



}
