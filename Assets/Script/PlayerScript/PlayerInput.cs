using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // 플레이어의 인풋에관한 모든 처리는 여기서 작성
    // 자세한 코드는 해당하는 스크립트에서 작성
    public Vector2 MoveInput { get; private set; }
    public bool AttackInput { get; private set; }

    // Update is called once per frame
    void Update()
    {
        // 대각선 이동거리 문제로 인한 normalized는 인풋에서 처리
        MoveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        // 공격은 마우스 좌클릭으로 설정
        AttackInput = Input.GetMouseButtonDown(0);
    }
}
