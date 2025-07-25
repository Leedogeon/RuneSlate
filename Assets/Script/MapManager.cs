using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public Transform SpawnPoint;

    [SerializeField] private GameObject prologue;

    public void invisivleObj(GameObject obj)
    {
        obj.SetActive(false);
    }

}
