using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlScript : MonoBehaviour
{
    public bool Move = false;
    [SerializeField] Transform Player;
    Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if(Move)
        {
            if(PlayerManager.Instance != null)
            {
                if(Player==null)
                {
                    setPlayer();
                }


                float distance = Vector3.Distance(transform.position, Player.position);
                if (distance < 1.5f)
                {
                    rigid.velocity = Vector3.zero; // ¸ØÃã

                    Move = false;
                    PlayerDataControll.CanControll = true;
                }
                else
                {
                    Vector3 dir = (Player.position - transform.position).normalized;
                    rigid.velocity = dir * 3f;

                }
            }
        }
    }

    public void GoToPlayer()
    {
        setPlayer();
        PlayerDataControll.CanControll = false;
        Player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Move = true;
    }
    public void setPlayer()
    {
        Player = PlayerManager.Instance.PlayerInstance.transform;
    }
}
