using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{

    private PlayerMovement movement;
    float DashCoolDown = 2f;
    bool isDash = false;
    bool canDash = true;
    [SerializeField]GameObject Player;
    [SerializeField] LayerMask Ground;
    [SerializeField] LayerMask mapWallLayer;
    [SerializeField] GameObject TestBlock;
    Vector3 direction;
    public void Awake()
    {
        movement = GetComponent<PlayerMovement>();
    }
/*    public IEnumerator Dash()
    {
        if (!canDash) yield break;
        isDash = true;
        canDash = false;
        if (movement != null)
        {
            Vector3 startPos = movement.transform.parent.position;

            // 08.02 회의 -> 구르기는 키보드로 지정하되, 정지상태라면 바라보는 방향으로 하도록 조정
            // 공격도중 캔슬기능 추가예정, 공격도중 캔슬시에도 키보드로 지정
            // 대시 목표 지점 = 현재 위치 + 입력 방향 * 거리

            // 이동중일땐 키보드방향에 맞춰서 -> 이후 playerAttack도중이라는 조건 추가
            // Vector2.zero인지 검사


            //Vector3 targetPos = startPos + direction * dashDistance;
            Vector3 targetPos;
            float dashDistance = movement.speed;
            if (movement.input.MoveInput != Vector2.zero)
            {
                //direction = new Vector3(movement.input.MoveInput.x, 0, movement.input.MoveInput.y).normalized;
                direction = movement.Rigid.velocity;
                targetPos = startPos + direction;
            }
            else // 정지상태라면 플레이어 인스턴스를 이용해 forward 방향으로
            {
                Player = PlayerManager.Instance.PlayerInstance;
                direction = Player.transform.forward.normalized;
                targetPos = startPos + direction * dashDistance;

            }

            float duration = .3f;
            float elapsed = 0f;

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                float t = elapsed / duration;

                // 경사를 체크하여서 y값이 달라지면 조정
                Vector3 pos = movement.transform.parent.position = Vector3.Lerp(startPos, targetPos, t);

                movement.Rigid.MovePosition(pos);
                if (Physics.Raycast(pos + Vector3.up * 2f, Vector3.down, out RaycastHit hit, 5f, Ground))
                {

                    if (hit.point.y > pos.y)
                    {
                        pos.y = hit.point.y; // 경사를 따라 올라가도록 y값 보정
                    }
                    movement.Rigid.MovePosition(pos);
                }
                yield return null;
            }
        }
        isDash = false;
        yield return new WaitForSeconds(DashCoolDown);
        canDash = true;
    }*/


    public IEnumerator Dash()
    {
        if (!canDash) yield break;
        isDash = true;
        canDash = false;

        // Rigidbody 컴포넌트 변수
        Rigidbody rigid = movement.Rigid;

        // 대시 시작 지점
        Vector3 startPos = rigid.position;

        Vector3 targetPos;

        // 대시 방향 설정
        Vector3 direction;
        if (movement.input.MoveInput != Vector2.zero)
        {
            direction = rigid.velocity;
            targetPos = startPos + direction;
        }
        else
        {
            Player = PlayerManager.Instance.PlayerInstance;
            direction = Player.transform.forward.normalized;
            targetPos = startPos + direction * movement.speed;
        }

        Debug.Log("direction = " + direction.normalized);

        float duration = .3f;
        float elapsed = 0f;

        // 이동 허용 여부를 판단하는 변수
        bool canMove = true;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            if (Physics.Raycast(rigid.position, direction, 1f, mapWallLayer))
            {
                Debug.Log("MapEnd");
                canMove = false;
            }

            // 앞으로 1m, 아래로 1m 지점에 레이를 쏴서 지형 경사 감지
            RaycastHit hit;
            if (Physics.Raycast(rigid.position + direction * 1f + Vector3.up * 1f, Vector3.down, out hit, 2f, Ground))
            {
                // 지형의 법선 벡터(normal)를 얻어옴
                Vector3 groundNormal = hit.normal;

                // Vector3.up(수직)과 groundNormal 사이의 각도를 측정
                float slopeAngle = Vector3.Angle(Vector3.up, groundNormal);

                // 경사각이 45도를 넘으면 이동을 멈춥니다.
                if (slopeAngle > 45f)
                {
                    Debug.Log("Wall");
                    // 벽에 닿으면 최종 목적지를 hit.point로 변경
                    targetPos = hit.point;
                }
            }

            // canMove가 true일 때만 위치를 이동시킵니다.
            if (canMove)
            {
                Vector3 nextPos = Vector3.Lerp(startPos, targetPos, t);

                // y값 보정 로직 (기존 코드)
                RaycastHit yHit;
                if (Physics.Raycast(nextPos + Vector3.up * 2f, Vector3.down, out yHit, 5f, Ground))
                {
                    if (yHit.point.y > nextPos.y)
                    {
                        nextPos.y = yHit.point.y;
                    }
                }

                rigid.MovePosition(nextPos);
            }

            yield return null;
        }

        isDash = false;
        yield return new WaitForSeconds(DashCoolDown);
        canDash = true;
    }
}
