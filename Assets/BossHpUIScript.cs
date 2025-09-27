using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHpUIScript : MonoBehaviour
{
    public Image HPUI;
    public float maxHp;
    public float curHp;
    public float hitDamge = 10f;
    public BossScript Boss;

    private void Awake()
    {
        Boss = FindObjectOfType<BossScript>();
        maxHp = Boss.maxHp;
        curHp = Boss.Hp;
        UpdateHealthBar();
    }


    void Update()
    {
        if (!FindPlayer()) return;

        curHp = Boss.Hp;
        UpdateHealthBar();
    }

    public bool FindPlayer()
    {
        if (Boss == null)
        {
            return false;
        }
        else
        {
            Boss = FindObjectOfType<BossScript>();
            maxHp = Boss.maxHp;
            curHp = Boss.Hp;
            return true;
        }
    }

    private void UpdateHealthBar()
    {
        float ratio = curHp / maxHp;
        HPUI.fillAmount = ratio;
        /*txt.text = curHp.ToString("0") + "/" + maxHp.ToString("0");*/
    }
}
