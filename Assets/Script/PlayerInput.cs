using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // �ٸ� ��ũ��Ʈ���� �Է°��� �������� ������, ������ �Ұ����ϰ� ĸ��ȭ
    public Vector2 MoveInput { get; private set; }
    public bool AttackInput { get; private set; }

    // Update is called once per frame
    void Update()
    {
        MoveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        AttackInput = Input.GetMouseButtonDown(0);
    }
}
