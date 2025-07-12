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

    // 회전의 경우는 Update가 조금더 어울린다고 하여 우선 Update 사용
    void Update()
    {
        // 공격을 할 경우 마우스위치를 바라보면서 공격
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(input.AttackInput)
        {
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, groundMask))
            {
                Vector3 dir = hit.point - transform.position;
                // 수평회전을 막기위해 y값은 0으로
                dir.y = 0;
                // 회전
                transform.forward = dir.normalized;
                Debug.Log("Attack");
            }
        }
    }
}
