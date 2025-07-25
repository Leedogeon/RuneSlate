using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.05f; // 한 글자당 시간
    [TextArea] public string fullText; // 전체 텍스트
    private string currentText = "";

    [SerializeField] private TextMeshProUGUI textUI; // TextMeshPro를 사용할 경우
    [SerializeField] private MapManager mapManager;

    void Start()
    {
        mapManager = FindObjectOfType<MapManager>();
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            textUI.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }

        yield return new WaitForSeconds(1f);
        mapManager.invisivleObj(gameObject);

    }
}
