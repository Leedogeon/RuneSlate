using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUIScript : MonoBehaviour
{
    public Image HPUI;
    public Text txt;
    public float maxHp;
    public float curHp;
    public float hitDamge = 10f;

    [SerializeField] public PlayerStats playerstats;

    private void Awake()
    {
        playerstats = PlayerManager.Instance.PlayerInstance.GetComponentInChildren<PlayerStats>();
        maxHp = playerstats.maxHp;
        curHp = playerstats.curHP;

        UpdateHealthBar();
    }

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (!FindPlayer()) return;

        UpdateHealthBar();
    }

    public bool FindPlayer()
    {
        if (playerstats == null)
        {
            return false;
        }
        else
        {
            playerstats = PlayerManager.Instance.PlayerInstance.GetComponentInChildren<PlayerStats>();
            curHp = playerstats.curHP;
            maxHp = playerstats.maxHp;
            return true;
        }
    }

    private void UpdateHealthBar()
    {
        float ratio = curHp / maxHp;
        HPUI.fillAmount = ratio;
        txt.text = curHp.ToString("0") + "/" + maxHp.ToString("0");
    }


    public void TakeDamage(float Damage)
    {
        curHp -= Damage;
        if (curHp < 1)
            curHp = 0;

        UpdateHealthBar();
    }

    public void HealDamage(float Heal)
    {
        curHp += Heal;
        if (curHp > maxHp)
            curHp = maxHp;
        UpdateHealthBar();
    }
}
