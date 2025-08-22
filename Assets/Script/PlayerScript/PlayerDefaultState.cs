using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable] // 이게있어야 JsonUtility가 직렬화 가능
public class PlayerDefaultState
{
    public float BaseHp = 100;
    public Vector3 StartPos;
    public int Lv = 1;

}
