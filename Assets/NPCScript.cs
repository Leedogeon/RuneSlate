using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    [SerializeField] public bool CanInteration = false;
    [SerializeField] public bool CanOpen = false;

    [SerializeField] GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void TalkOpen()
    {
        if (!PlayerDataControll.NPC1CanTalk) return;

        if (gameManager != null)
        {
            gameManager.TalkUI(5);
            PlayerDataControll.CurTalkId = 5;
            PlayerDataControll.NPC1CanTalk = false;
        }
    }
}
