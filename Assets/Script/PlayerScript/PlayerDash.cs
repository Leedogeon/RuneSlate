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
    Vector3 direction;
    public void Awake()
    {
        movement = GetComponent<PlayerMovement>();
    }
    public IEnumerator Dash()
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
                targetPos = startPos+ direction;
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
                if (Physics.Raycast(pos + Vector3.up * 2f, Vector3.down, out RaycastHit hit, 5f,Ground))
                {
                    pos.y = hit.point.y; // 땅 높이에 맞춤
                    movement.transform.parent.position = pos;
                }
                yield return null;
            }
        }
        isDash = false;
        yield return new WaitForSeconds(DashCoolDown);
        canDash = true;
    }
}
