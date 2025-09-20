using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    // 이동관련 스크립트
    // 인풋자체는 PlayerInput에서 받아오고, 나머지 이동관련 스크립트는 여기서 작성
    public PlayerInput input;
    public Rigidbody Rigid;
    public Transform cam;
    PlayerAnimationController animCon;
    [SerializeField] PlayerDash Dash;
    // 유니티 자체에서 컨트롤하며 조정하기위해 [SerializeField] 사용
    [SerializeField] public float speed = 5f;
    float walkSpeed = .5f;
    float rotateSpeed = 10f;
    float slopeAngle = 0f;
    Vector3 slopeNormal;
    [SerializeField] PlayerAttack isattack;
    private void Awake()
    {
        input = transform.parent.GetComponentInChildren<PlayerInput>();
        Rigid = GetComponentInParent<Rigidbody>();
        animCon = transform.parent.GetComponentInChildren<PlayerAnimationController>();
        Dash = transform.parent.GetComponentInChildren<PlayerDash>();
        cam = FindObjectOfType<FollowCamera>().transform;
        isattack = transform.parent.GetComponentInChildren<PlayerAttack>();
    }

    private void FixedUpdate()
    {
        // 이동값, normalized는 input에서 미리 처리
        Vector3 dir = new Vector3(input.MoveInput.x, 0, input.MoveInput.y).normalized;
        // 자연스럽게 하기위해 velocity 사용
        // 카메라 회전값을 적용
        float targetAngle = cam.eulerAngles.y;
        Quaternion camRot = Quaternion.Euler(0, targetAngle, 0);
        //Rigid.velocity = dir * speed;
        // 중력의 영향을 정상적으로 받기위해 y값을 따로 설정
        // x,z값의 경우 speed의 영향을 받아야하니 먼저 곱해주고 y값은 따로 설정

        // vector3와 Quaternion은 Quaternion*vector3 순서로 해야됨
        Vector3 newVelocity = camRot * dir * speed * (input.WalkInput ? walkSpeed : 1);
        //if (Rigid.velocity.y > 0.5f) newVelocity.y = 0;
        if (Rigid.velocity.y > 0f)
        {
            newVelocity.y = 0f;

        }
        else newVelocity.y = Rigid.velocity.y;

        Rigid.velocity = newVelocity;

        if (PlayerDataControll.AttackCantMove)
        {
            Rigid.velocity = Vector3.zero;
        }

        if (input.DashInput)
        {
            StartCoroutine(Dash.Dash());
        }

        // 캐릭터의 forward를 이용해서 회전시킨다
        // Slerp를 이용하여 자연스럽게 회전하게 하고
        // 회전에 y값은 영향받지 않게 할려고 newVelocity가 아닌 dir을 이용
        // rotateSpeed는 적당히 자연스러운 느낌을 받게 커스텀 조정
        // 임시로 공격키가 입력중일땐 방향전환은 하지않도록 설정 - 이후 공격 모션도중 안하는걸로 수정
        if (!PlayerDataControll.AttackCantMove)
        transform.parent.forward = Vector3.Slerp(transform.parent.forward, camRot * dir, Time.deltaTime * rotateSpeed);
    }

/*    void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            slopeNormal = contact.normal;
            slopeAngle = Vector3.Angle(slopeNormal, Vector3.up);
        }
    }*/
}
