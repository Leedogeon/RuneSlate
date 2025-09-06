using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TalkUIScript : TextManager
{
    public Transform target;       // 말풍선을 띄울 캐릭터
    public Vector3 offset = new Vector3(0, 2f, 0); // 머리 위 위치
    public RectTransform balloonUI; // 말풍선 UI 오브젝트 (RectTransform)
    public Canvas canvas;          // UI 캔버스

    [SerializeField] QuestUIText quest;
    [SerializeField] GameManager gameManager;

    private Dictionary<int, string> TalkUIForPlayer = new Dictionary<int, string>()
    {
        {1, "곧 있으면 기사 임용시험인데 붙을수있을까...\n이번엔 꼭 붙어야 돼" },
        {2, "일단 순찰이나 마저하자" },
        {3, "무슨 소란이지? 확인 해봐야겠어" },
        {4, "이런! 빨리 저들을 도우러 가야겠어!" },
        {5, "이봐요! 정신 차려요!" }
    };

    private void Awake()
    {
        if (PlayerManager.Instance != null)
            target = PlayerManager.Instance.PlayerInstance.transform;
        gameManager = FindObjectOfType<GameManager>();
    }

    // 말풍선 위치 설정
    public void setBalloonPos()
    {
        Vector3 worldPos = target.position + offset;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            screenPos,
            canvas.worldCamera,
            out Vector2 uiPos);

        balloonUI.localPosition = uiPos;
    }
    private string setText(int TalkId)
    {
        return TalkUIForPlayer[TalkId];
    }
    public IEnumerator ShowText(int TalkId)
    {
        setBalloonPos();
        if (TalkUIForPlayer.ContainsKey(TalkId))
        {
            fullText = setText(TalkId);
        }

        textUI.text = "";

        // 시간 기반으로 한 글자씩 출력하며 마우스 클릭을 매 프레임마다 체크
        float timer = 0f;
        int charIndex = 0;

        while (charIndex < fullText.Length)
        {
            // 마우스 클릭 시, 남은 텍스트를 모두 출력
            if (Input.GetMouseButtonDown(0))
            {
                textUI.text = fullText;
                break;
            }

            // 타이머가 타이핑 속도를 넘어가면 다음 글자를 출력
            if (timer >= typingSpeed)
            {
                textUI.text += fullText[charIndex];
                charIndex++;
                timer = 0f;
            }

            timer += Time.deltaTime;
            yield return null; // 한 프레임 대기
        }

        // 한 프레임 대기
        yield return null;
        // 모든 텍스트가 출력된 후, 다시 마우스 클릭을 기다립니다.
        /*while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }*/
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        PlayerDataControll.CurTalkId++;


        if (TalkId == 2)
        {
            gameManager.QuestOpen();
/*            quest.gameObject.SetActive(true);
            quest.ShowQuest(1);*/
        }

        if (TalkId == 1)
        {
            // 한프레임 대기하여 GetMouseButton값을 false상태로
            yield return null;
            // TalkId가 1인 경우, 대화 종료 대신 다음 대화(ShowText(2))를 시작
            StartCoroutine(ShowText(PlayerDataControll.CurTalkId));
            yield break; // 현재 코루틴을 여기서 종료
        }
        else
        {
            // TalkId가 1이 아닌 경우, 대화 종료 처리
            PlayerDataControll.CanControll = true;
            gameObject.SetActive(false);
        }
    }
}
