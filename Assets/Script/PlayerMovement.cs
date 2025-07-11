using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    // �̵����� ��ũ��Ʈ
    // ��ǲ��ü�� PlayerInput���� �޾ƿ���, ������ �̵����� ��ũ��Ʈ�� ���⼭ �ۼ�
    PlayerInput Input;
    Rigidbody Rigid;
    // ����Ƽ ��ü���� ��Ʈ���ϸ� �����ϱ����� [SerializeField] ���
    [SerializeField] public float speed = 5f;

    private void Awake()
    {
        Input = GetComponent<PlayerInput>();
        Rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // �̵���, normalized�� input���� �̸� ó��
        Vector3 dir = new Vector3(Input.MoveInput.x, 0, Input.MoveInput.y);
        // �ڿ������� �ϱ����� velocity ���
        Rigid.velocity = dir * speed;

    }
}
