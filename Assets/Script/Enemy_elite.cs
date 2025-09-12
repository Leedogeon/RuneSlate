using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_elite : Enemy
{
    MapManager mapManager;

    protected void Awake()
    {
        mapManager = FindObjectOfType<MapManager>();
    }

    public override void Death(int Index)
    {
        mapManager.ElitePos = this.transform.position;
        base.Death(PlayerDataControll.TutorialEnemyDeathQuestId);
    }
}
