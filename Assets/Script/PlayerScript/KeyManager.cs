using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 입력 Key , 마지막엔  KEYCOUNT를 넣어서 갯수 체크
public enum KeyAction { UP, DOWN, LEFT, RIGHT, ATTACK, DASH,KEYCOUNT }
// 키 입력에 대한 Key(이름)와 해당하는 키 입력 버튼을 가지는 Dictionary
public static class KeySetting { public static Dictionary<KeyAction, KeyCode> keys = new Dictionary<KeyAction, KeyCode>(); }

public class KeyManager : MonoBehaviour
{
    // 기본으로 지정해놓을 키의 입력값들, Mouse0 = 좌클릭, Mouse1 = 우클릭 / Mouse2 = 휠클릭, 이후는 없는 마우스들도 있는 측면버튼들
    KeyCode[] defaultKeys = new KeyCode[] { KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D, KeyCode.Mouse0, KeyCode.Mouse1};


    private void Awake()
    {
        // 미지정시
        if (KeySetting.keys.Count == 0)
        {
            for (int i = 0; i < (int)KeyAction.KEYCOUNT; i++)
            {
                // 각각의 Key에 해당하는 키를 넣어준다
                KeySetting.keys.Add((KeyAction)i, defaultKeys[i]);
            }
        }

    }

}
