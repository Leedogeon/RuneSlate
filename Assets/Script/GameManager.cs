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
    [SerializeField] MapManager mapManager;
    [SerializeField] GameObject ElitePref;
    [SerializeField] GameObject SpawnEffect;
    [SerializeField] GameObject BossPref;
    [SerializeField] public GameObject BossHPUI;
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
        mapManager = FindObjectOfType<MapManager>();
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

    // 임시처리
    public void QuestOpen(int index)
    {
        Debug.Log("CurQuestId = " + PlayerDataControll.CurQuestId);
        questText.gameObject.SetActive(true);
        questText.ShowQuest(index);
    }

    public void SpawnElite()
    {
        StartCoroutine(SpawnBoss());
    }


    IEnumerator SpawnBoss()
    {
        yield return new WaitForSeconds(1f);
        questText.gameObject.SetActive(false);
        // Boss 소환
        GameObject Boss = Instantiate(ElitePref, mapManager.ElitePos, ElitePref.transform.rotation);

        PlayerDataControll.CanControll = false;
        // 다시 1초 대기
        yield return new WaitForSeconds(1f);
        GameObject Effect = Instantiate(SpawnEffect, mapManager.ElitePos, SpawnEffect.transform.rotation);
        yield return new WaitForSeconds(1f);
        // 2초 동안 scale Lerp
        Vector3 originalScale = Boss.transform.localScale;
        Vector3 targetScale = originalScale * 1.3f;
        float duration = 2f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            Boss.transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        Destroy(Effect);
        QuestOpen(5);


        Destroy(Boss);
        StartCoroutine(BossChange());


        // 최종값 보정
//        Boss.transform.localScale = targetScale;
/*        PlayerDataControll.CanControll = true;
        Boss.GetComponent<Enemy_TutorialBoss>().CanAttack_B = true;*/
    }

    IEnumerator BossChange()
    {
        GameObject Boss_R = Instantiate(BossPref,mapManager.ElitePos,BossPref.transform.rotation);
        Boss_R.transform.LookAt(PlayerManager.Instance.PlayerInstance.transform.position);
        BossHPUI.SetActive(true);
        yield return null;
    }
}
