using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 다른 스크립트에서 입력값을 받을수는 있지만, 수정은 불가능하게 캡슐화
    // 코드를 나눠서 제작중
    public PlayerInput Input { get; private set; }
    public PlayerMovement Movement { get; private set; }

    private void Awake()
    {
        Input = GetComponent<PlayerInput>();
        Movement = GetComponent<PlayerMovement>();
    }

    void Start()
    {
    }
    void Update()
    {
        // 공격 인풋 테스트중
        if(Input.AttackInput)
        {
            Debug.Log("Attack_Main");
        }
    }
}
