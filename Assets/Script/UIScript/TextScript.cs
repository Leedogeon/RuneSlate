using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class TextScript : TextManager
{
    private string currentText = "";

    [SerializeField] private MapManager mapManager;

    void Start()
    {
        mapManager = FindObjectOfType<MapManager>();
        //StartCoroutine(ShowText());
    }

    public IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            textUI.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }

        yield return new WaitForSeconds(1f);
        mapManager.TempStartTalk();
        mapManager.invisivleObj(gameObject);
    }
}
