using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    [SerializeField] protected float typingSpeed = 0.05f; // 한 글자당 시간
    [TextArea] public string fullText; // 전체 텍스트
    [SerializeField] protected TextMeshProUGUI textUI;
}
