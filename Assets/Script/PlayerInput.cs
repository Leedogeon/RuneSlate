using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // �÷��̾��� ��ǲ������ ��� ó���� ���⼭ �ۼ�
    // �ڼ��� �ڵ�� �ش��ϴ� ��ũ��Ʈ���� �ۼ�
    public Vector2 MoveInput { get; private set; }
    public bool AttackInput { get; private set; }

    // Update is called once per frame
    void Update()
    {
        // �밢�� �̵��Ÿ� ������ ���� normalized�� ��ǲ���� ó��
        MoveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        // ������ ���콺 ��Ŭ������ ����
        AttackInput = Input.GetMouseButtonDown(0);
    }
}
