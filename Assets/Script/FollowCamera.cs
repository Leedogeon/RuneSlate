using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] public Transform Player;
    [SerializeField] private Vector3 offset;
    private void Start()
    {
        // 인스턴스는 playerManager를 가르키기 때문에
        // 인스턴스에 있는 플레이어 인스턴스값을 받아와야함
        Player = PlayerManager.Instance.PlayerInstance.transform;
    }
    private void LateUpdate()
    {
        if (Player == null) return;
        // offset으로 카메라 위치 조정
        // 각도는 우선 유니티 인스펙터에서 설정
        transform.position = Player.position + offset; 
    }
}
