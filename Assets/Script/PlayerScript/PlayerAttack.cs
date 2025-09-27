using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]PlayerInput input;
    [SerializeField]Rigidbody Rigid;
    LayerMask groundMask;
    [SerializeField] PlayerAnimationController animCon;
    [SerializeField] public bool[] IsAttack;
    [SerializeField] LayerMask EnemyLayer;
    bool CanAttack = true;
    public int Blend;
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
        if (!IsAttack[0] && !IsAttack[1])
        {
            GetComponent<BoxCollider>().enabled = false;
            PlayerDataControll.AttackCantMove = false;
        }
        else
        {
            GetComponent<BoxCollider>().enabled = true;
            PlayerDataControll.AttackCantMove = true;
        }
        if (IsAttack[1]) return;
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


                if (IsAttack[0])
                    Blend = 1;
                else Blend = 0;
                StartCoroutine(Attack(Blend));
                
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.layer == 20)
        {
            if(other.gameObject.GetComponent<Enemy>())
                StartCoroutine(other.gameObject.GetComponent<Enemy>().Damaged());
        }

    }

    public IEnumerator Attack(int Blend)
    {
        if(Blend == 1)
        {
            yield return new WaitWhile(() => IsAttack[0]);
        }
        animCon.Attack(Blend);
        IsAttack[Blend] = true;
        yield return new WaitWhile(() => IsAttack[Blend]);
        IsAttack[Blend] = false;
    }
}
