using System.Collections;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.UI.Image;

public class Enemy : MonoBehaviour
{
    public static event Action<int> OnEnemyDeath;
    float radius = 10f;
    [SerializeField] LayerMask layerMask;
    Collider[] hits;
    Rigidbody rigid;

    [SerializeField] float speed = 3f;
    bool isChasing = false;
    bool isAttack = false;
    bool CanAttack = true;
    [SerializeField]Transform TargetPos;
    Animator anim;

    [SerializeField] public float maxHp = 30;
    [SerializeField] public float Hp = 30;
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    protected void Update()
    {

        anim.SetBool("isChasing", isChasing);

        anim.SetBool("isAttack", isAttack);

    }

    protected virtual void FixedUpdate()
    {
        if (TargetPos == null)
        {
            isChasing = false;
            Detect();
            return;
        }

        if(TargetPos != null)
        {
            Chasing(TargetPos);
        }
    }

    public void Chasing(Transform FindObj)
    {
        float distance = Vector3.Distance(transform.position, FindObj.transform.position);

        
        if (distance < 1.5f)
        {
            isChasing = false;
            rigid.velocity = Vector3.zero; // 멈춤
            if(CanAttack)
                StartCoroutine(Attack());
        }
        else
        {

            isChasing = true;
            Vector3 dir = (FindObj.transform.position - transform.position).normalized;
            transform.forward = Vector3.Slerp(transform.forward, dir, Time.deltaTime * 10f);

            rigid.velocity = dir * speed;
            isAttack = false;
        }
    }

    IEnumerator Attack()
    {
        CanAttack = false;
        isAttack = true;
        yield return new WaitForSeconds(1f);
        isAttack = false;
        yield return new WaitForSeconds(1.5f);
        CanAttack = true;
    }
    public IEnumerator Damaged()
    {
        if(Hp >0)
        {
            anim.SetTrigger("Damaged");
            Hp -= 10;
            if (Hp <= 0)
            {
                Death(PlayerDataControll.TutorialEnemyDeathQuestId);
            }
        }
        yield return null;
    }

    public void Detect()
    {
        isAttack = false;
        hits = Physics.OverlapSphere(gameObject.transform.position, radius, layerMask);
        if(TargetPos == null)
        {
            foreach(Collider hit in hits)
            {
                if(hit.gameObject.tag == "Player")
                {
                    TargetPos = hit.transform;
                }
            }
        }
    }

    // 편의용: 에디터에서 반경 표시
    /*void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        float worldRadius = radius * transform.lossyScale.x;
        Gizmos.DrawWireSphere(gameObject.transform.position, worldRadius);
    }*/

    public virtual void Death(int Index)
    {
        OnEnemyDeath?.Invoke(Index);
        Destroy(gameObject);
    }


}
