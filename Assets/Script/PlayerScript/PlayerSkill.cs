using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    PlayerInput input;
    private void Awake()
    {
        input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        // 테스트용 디버그
        for(int i = 0; i<input.SkillInput.Length; i++)
        {
            if (input.SkillInput[i]) Debug.Log($"숫자키 {i+1} 입력");
        }
    }

}
