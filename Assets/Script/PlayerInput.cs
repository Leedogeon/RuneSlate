using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // 다른 스크립트에서 입력값을 받을수는 있지만, 수정은 불가능하게 캡슐화
    public Vector2 MoveInput { get; private set; }
    public bool AttackInput { get; private set; }

    // Update is called once per frame
    void Update()
    {
        MoveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        AttackInput = Input.GetMouseButtonDown(0);
    }
}
