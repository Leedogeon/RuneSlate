using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable] // 이게있어야 JsonUtility가 직렬화 가능
public class SaveData
{
    public float playerX;
    public float playerY;
    public float playerZ;

    public int hp;
    public int level;

    public int playTime;
    public string Chapter;

}
