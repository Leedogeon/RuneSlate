using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.05f; // �� ���ڴ� �ð�
    [TextArea] public string fullText; // ��ü �ؽ�Ʈ
    private string currentText = "";

    [SerializeField] private TextMeshProUGUI textUI; // TextMeshPro�� ����� ���
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
