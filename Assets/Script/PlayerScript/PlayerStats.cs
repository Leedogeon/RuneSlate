using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHp;
    public float curHP;

    [SerializeField]PlayerHealth healthUI;

    private void Awake()
    {
        LoadPlayerDefaultStats();
        healthUI = FindObjectOfType<PlayerHealth>(true);

    }
    public void LoadPlayerDefaultStats()
    {
        PlayerDefaultState defaultState = new PlayerDefaultState();
        maxHp = defaultState.BaseHp;
        curHP = defaultState.BaseHp;
    }
    
}
