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
        // �׽�Ʈ�� �����
        for(int i = 0; i<input.SkillInput.Length; i++)
        {
            if (input.SkillInput[i]) Debug.Log($"����Ű {i+1} �Է�");
        }
    }

}
