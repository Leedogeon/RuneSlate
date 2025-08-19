using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion_Heal : MonoBehaviour
{

    [SerializeField]PlayerStats playerstats;
    [SerializeField] PlayerHealth health;
    private void Awake()
    {
        playerstats = GetComponent<PlayerStats>();
        health = FindObjectOfType<PlayerHealth>(true);
    }
    public void Heal_Player(float heal)
    {
        if (health != null)
        {
            health.HealDamage(heal);
            playerstats.curHP = health.hitPoint;
        }
    }

}
