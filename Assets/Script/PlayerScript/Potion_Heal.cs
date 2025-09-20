using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion_Heal : MonoBehaviour
{

    [SerializeField] PlayerStats playerstats;
    [SerializeField] PlayerHPUIScript health;
    private void Awake()
    {
        playerstats = GetComponent<PlayerStats>();
        health = FindObjectOfType<PlayerHPUIScript>(true);
    }
    public void Heal_Player(float heal)
    {
        if (health != null)
        {
            health.HealDamage(heal);
            playerstats.curHP = health.curHp;
        }
    }

}
