using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public static class PlayerDataControll
{
    




    public static bool CanControll = false;
    public static bool KeyUIOpen = false;
    public static Vector3 PlayerStartPosFromLoad;
    public static int SaveLoadIndex = -1;
    public static int PlayTime = 0;
    public static int Lv = 1;
    public static int BaseHp;
    public static float DefaultSpeed = 5f;

    public static bool AttackCantMove = false;

    //public static int AttackCount = 0;

    public static Vector3 ReSpawnPoint;

    public static bool NPC1CanTalk = false;



    #region 
    public static bool IsFileStart = true;
    #endregion


    #region ´ëÈ­
    public static int CurTalkId = 1;
    #endregion

    #region Äù½ºÆ®
    public static int CurQuestId = 1;
    public static int TutorialEnemyDeathQuestId = 4;
    #endregion
}
