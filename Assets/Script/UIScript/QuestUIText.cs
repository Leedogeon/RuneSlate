using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestUIText :TextManager
{
    [SerializeField] Image BackImage;
    public float padding = 3f;
    private Dictionary<int, string> questTexts = new Dictionary<int, string>()
    {
        {1, "WASD로 이동하라" },
        {2, "마우스 좌클릭으로 적을 공격하라\n"},
        {3, "LEFT SHIFT로 적의 공격을 회피하라\n" },
        {4, "적들을 모두 제거하라 ({0}/6) " },
        {5, "부서진 마차를 F키를 눌러 조사하자" }
    };
    private Dictionary<int, int> questProgress = new Dictionary<int, int>()
    {
        {4,0 }
    };
    public void ShowQuest(int questId)
    {
        textUI.text = null;
        if (questId == 2)
        {
            textUI.text += questTexts[2];
            textUI.text += questTexts[3];
            //textUI.text += questTexts[4];
            if (questProgress.ContainsKey(4))
            {
                textUI.text += string.Format(questTexts[4], questProgress[4]);
            }
        }
        else
        {
            if (questTexts.ContainsKey(questId))
                textUI.text = questTexts[questId];
            else
                textUI.text = null;
        }

        float textHeight = textUI.preferredHeight;
        RectTransform imgRecTransform = BackImage.GetComponent<RectTransform>();
        imgRecTransform.sizeDelta = new Vector2(imgRecTransform.sizeDelta.x, textHeight + 3f);

    }
    public void UpdateQuestProgress(int questId)
    {
        Debug.Log("EnemyDestroy");
        if(questProgress.ContainsKey(4))
        {
            questProgress[4]++;
            if(PlayerDataControll.CurQuestId == 3)
                ShowQuest(2);
        }
    }

}
