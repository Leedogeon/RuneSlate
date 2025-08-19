using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 다른 스크립트에서 입력값을 받을수는 있지만, 수정은 불가능하게 캡슐화
    // 코드를 나눠서 제작중
    [SerializeField] PlayerInput Input;
    [SerializeField] PlayerMovement Movement;
    private void Awake()
    {
        Input = GetComponentInChildren<PlayerInput>();
        Movement = GetComponentInChildren<PlayerMovement>();
    }

    void Start()
    {
    }
    void Update()
    {
        // 공격 인풋 테스트중
        if(Input.AttackInput)
        {
        }

    }
}
