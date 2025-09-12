using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_TutorialBoss : Enemy
{
    public bool CanAttack = false;
    private void Awake()
    {
        Hp = 50;
    }

    public override void Death(int index)
    {
        base.Death(6);
    }

    protected override void FixedUpdate()
    {
        if (!CanAttack) return;
        base.FixedUpdate();
    }

}
