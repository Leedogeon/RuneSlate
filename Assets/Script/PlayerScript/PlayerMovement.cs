using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    // �̵����� ��ũ��Ʈ
    // ��ǲ��ü�� PlayerInput���� �޾ƿ���, ������ �̵����� ��ũ��Ʈ�� ���⼭ �ۼ�
    PlayerInput input;
    Rigidbody Rigid;
    // ����Ƽ ��ü���� ��Ʈ���ϸ� �����ϱ����� [SerializeField] ���
    [SerializeField] public float speed = 5f;
    float rotateSpeed = 10f;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        Rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // �̵���, normalized�� input���� �̸� ó��
        Vector3 dir = new Vector3(input.MoveInput.x, 0, input.MoveInput.y);
        // �ڿ������� �ϱ����� velocity ���
        //Rigid.velocity = dir * speed;
        // �߷��� ������ ���������� �ޱ����� y���� ���� ����
        // x,z���� ��� speed�� ������ �޾ƾ��ϴ� ���� �����ְ� y���� ���� ����
        Vector3 newVelocity = dir * speed;
        newVelocity.y = Rigid.velocity.y;
        Rigid.velocity = newVelocity;

        // ĳ������ forward�� �̿��ؼ� ȸ����Ų��
        // Slerp�� �̿��Ͽ� �ڿ������� ȸ���ϰ� �ϰ�
        // ȸ���� y���� ������� �ʰ� �ҷ��� newVelocity�� �ƴ� dir�� �̿�
        // rotateSpeed�� ������ �ڿ������� ������ �ް� Ŀ���� ����
        transform.forward = Vector3.Slerp(transform.forward, dir, Time.deltaTime * rotateSpeed);

    }
}
