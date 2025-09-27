using System.Collections;
using UnityEngine;

public class BossScript : Enemy
{
    public bool CanAttack_B = true;
    private void Awake()
    {
        Hp = 100;
        maxHp = 100;
    }
   protected override void Start()
    {
        base.Start();
        anim.SetTrigger("Start");
    }
    public override void Death(int index)
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.BossHPUI.SetActive(false);
        base.Death(6);
    }

    protected override void FixedUpdate()
    {
        if (!CanAttack_B) return;
        base.FixedUpdate();
    }

    public override void Chasing(Transform FindObj)
    {
        if(!PlayerDataControll.CanControll || Hp <= 0)
        {
            return;
        }

        float distance = Vector3.Distance(transform.position, FindObj.transform.position);

        if (distance < 2f)
        {
            isChasing = false;
            rigid.velocity = Vector3.zero; // ¸ØÃã
            if (CanAttack)
            {
                StartCoroutine(Attack());
            }
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

    public override IEnumerator Attack()
    {
        CanAttack = false;
        isAttack = true;
        anim.SetTrigger("Attack");

        yield return new WaitForSeconds(1.5f);
        CanAttack = true;
        isAttack = false;
    }
}
