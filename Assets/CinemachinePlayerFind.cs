using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class CinemachinePlayerFind : MonoBehaviour
{
    [SerializeField]private CinemachineVirtualCamera Instance;
    [SerializeField] Transform player;
    [SerializeField] private Vector3 offset;
    private void Start()
    {
        Instance = this.GetComponent<CinemachineVirtualCamera>();
    }

    private void LateUpdate()
    {
        player = PlayerManager.Instance.PlayerInstance.transform;
        if (player == null) return;
        // offset으로 카메라 위치 조정
        // 각도는 우선 유니티 인스펙터에서 설정
        transform.position = player.position + offset;
        Instance.LookAt = player;

    }

/*    public void SetPlayerInCinemachine()
    {
        
        Instance.LookAt = player;

    }*/

}
