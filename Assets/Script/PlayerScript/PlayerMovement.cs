using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    // 이동관련 스크립트
    // 인풋자체는 PlayerInput에서 받아오고, 나머지 이동관련 스크립트는 여기서 작성
    PlayerInput input;
    Rigidbody Rigid;
    // 유니티 자체에서 컨트롤하며 조정하기위해 [SerializeField] 사용
    [SerializeField] public float speed = 5f;
    float rotateSpeed = 10f;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        Rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // 이동값, normalized는 input에서 미리 처리
        Vector3 dir = new Vector3(input.MoveInput.x, 0, input.MoveInput.y);
        // 자연스럽게 하기위해 velocity 사용
        //Rigid.velocity = dir * speed;
        // 중력의 영향을 정상적으로 받기위해 y값을 따로 설정
        // x,z값의 경우 speed의 영향을 받아야하니 먼저 곱해주고 y값은 따로 설정
        Vector3 newVelocity = dir * speed;
        newVelocity.y = Rigid.velocity.y;
        Rigid.velocity = newVelocity;

        // 캐릭터의 forward를 이용해서 회전시킨다
        // Slerp를 이용하여 자연스럽게 회전하게 하고
        // 회전에 y값은 영향받지 않게 할려고 newVelocity가 아닌 dir을 이용
        // rotateSpeed는 적당히 자연스러운 느낌을 받게 커스텀 조정
        transform.forward = Vector3.Slerp(transform.forward, dir, Time.deltaTime * rotateSpeed);

    }
}
