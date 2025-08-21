using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]PlayerInput input;
    [SerializeField]Rigidbody Rigid;
    LayerMask groundMask;
    [SerializeField] PlayerAnimationController animCon;
    [SerializeField] public bool IsAttack = false;
    private void Awake()
    {
        input = transform.parent.GetComponentInChildren<PlayerInput>();
        Rigid = GetComponentInParent<Rigidbody>();
        animCon = transform.parent.GetComponentInChildren<PlayerAnimationController>();
        groundMask = LayerMask.GetMask("Ground");
    }

    // 회전의 경우는 Update가 조금더 어울린다고 하여 우선 Update 사용
    void Update()
    {
        // 공격을 할 경우 마우스위치를 바라보면서 공격
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(input.AttackInput)
        {
            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                Vector3 dir = hit.point - transform.parent.position;
                // 수평회전을 막기위해 y값은 0으로
                dir.y = 0;
                // 회전
                transform.parent.forward = dir.normalized;

                animCon.Attack();
                //StartCoroutine(Attack());
            }
        }
    }

/*    public IEnumerator Attack()
    {
        // 임시적용 - animCon.Attack(); 외에 기능없음
        IsAttack = true;
        yield return new WaitForSeconds(3f);
        IsAttack = false;
    }*/
}
