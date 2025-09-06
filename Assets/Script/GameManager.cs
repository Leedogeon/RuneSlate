using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] QuestUIText QuestUIText;
    [SerializeField] TalkUIScript TalkScript;
    [SerializeField] TextScript TxtScript;
    [SerializeField] QuestUIText questText;
    private void OnEnable()
    {
        Enemy.OnEnemyDeath += QuestUIText.UpdateQuestProgress;
    }

    private void OnDisable()
    {
        Enemy.OnEnemyDeath -= QuestUIText.UpdateQuestProgress;
    }
    private void Start()
    {
        TextUI();
    }
    public void TextUI()
    {
        StartCoroutine(ShowStartTextUI());
    }
    private IEnumerator ShowStartTextUI()
    {
        yield return TxtScript.ShowText();
        yield return new WaitForSeconds(1f);
        TalkUI(1);
    }
    public void TalkUI(int TalkId)
    {
        TalkScript.gameObject.SetActive(true);
        PlayerDataControll.CanControll = false;
        Debug.Log($"TalkId = {TalkId}");
        StartCoroutine(TalkScript.ShowText(TalkId));
    }

    public void QuestOpen()
    {
        Debug.Log("CurQuestId = " + PlayerDataControll.CurQuestId);
        questText.gameObject.SetActive(true);
        questText.ShowQuest(PlayerDataControll.CurQuestId++);
    }

}
