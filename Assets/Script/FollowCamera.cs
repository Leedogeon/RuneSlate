using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] public Transform Player;
    [SerializeField] private Vector3 offset;
    private void Start()
    {
        // �ν��Ͻ��� playerManager�� ����Ű�� ������
        // �ν��Ͻ��� �ִ� �÷��̾� �ν��Ͻ����� �޾ƿ;���
        Player = PlayerManager.Instance.PlayerInstance.transform;
    }
    private void LateUpdate()
    {
        if (Player == null) return;
        // offset���� ī�޶� ��ġ ����
        // ������ �켱 ����Ƽ �ν����Ϳ��� ����
        transform.position = Player.position + offset; 
    }
}
