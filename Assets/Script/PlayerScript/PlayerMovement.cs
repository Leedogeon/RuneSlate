using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    // 이동관련 스크립트
    // 인풋자체는 PlayerInput에서 받아오고, 나머지 이동관련 스크립트는 여기서 작성
    PlayerInput Input;
    Rigidbody Rigid;
    // 유니티 자체에서 컨트롤하며 조정하기위해 [SerializeField] 사용
    [SerializeField] public float speed = 5f;

    private void Awake()
    {
        Input = GetComponent<PlayerInput>();
        Rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // 이동값, normalized는 input에서 미리 처리
        Vector3 dir = new Vector3(Input.MoveInput.x, 0, Input.MoveInput.y);
        // 자연스럽게 하기위해 velocity 사용
        //Rigid.velocity = dir * speed;
        // 중력의 영향을 정상적으로 받기위해 y값을 따로 설정
        // x,z값의 경우 speed의 영향을 받아야하니 먼저 곱해주고 y값은 따로 설정
        Vector3 newVelocity = dir * speed;
        newVelocity.y = Rigid.velocity.y;
        Rigid.velocity = newVelocity;

    }
}
