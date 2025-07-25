using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �Է� Key , ��������  KEYCOUNT�� �־ ���� üũ
public enum KeyAction { UP, DOWN, LEFT, RIGHT, ATTACK, DASH, SKILL1, SKILL2, SKILL3, SKILL4,  KEYCOUNT }
// Ű �Է¿� ���� Key(�̸�)�� �ش��ϴ� Ű �Է� ��ư�� ������ Dictionary
public static class KeySetting { public static Dictionary<KeyAction, KeyCode> keys = new Dictionary<KeyAction, KeyCode>(); }

public class KeyManager : MonoBehaviour
{
    // �⺻���� �����س��� Ű�� �Է°���, Mouse0 = ��Ŭ��, Mouse1 = ��Ŭ�� / Mouse2 = ��Ŭ��, ���Ĵ� ���� ���콺�鵵 �ִ� �����ư��
    KeyCode[] defaultKeys = new KeyCode[] { KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D, KeyCode.Mouse0, KeyCode.Mouse1,KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4};


    private void Awake()
    {
        // ��������
        if (KeySetting.keys.Count == 0)
        {
            for (int i = 0; i < (int)KeyAction.KEYCOUNT; i++)
            {
                // ������ Key�� �ش��ϴ� Ű�� �־��ش�
                KeySetting.keys.Add((KeyAction)i, defaultKeys[i]);
            }
        }

    }

}
