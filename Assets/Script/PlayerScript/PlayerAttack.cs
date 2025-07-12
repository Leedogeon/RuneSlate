using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    PlayerInput input;
    Rigidbody Rigid;
    LayerMask groundMask;
    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        Rigid = GetComponent<Rigidbody>();
        groundMask = LayerMask.GetMask("Ground");
    }

    // ȸ���� ���� Update�� ���ݴ� ��︰�ٰ� �Ͽ� �켱 Update ���
    void Update()
    {
        // ������ �� ��� ���콺��ġ�� �ٶ󺸸鼭 ����
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(input.AttackInput)
        {
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, groundMask))
            {
                Vector3 dir = hit.point - transform.position;
                // ����ȸ���� �������� y���� 0����
                dir.y = 0;
                // ȸ��
                transform.forward = dir.normalized;
                Debug.Log("Attack");
            }
        }
    }
}
