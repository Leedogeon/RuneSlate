using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // ���⼭ �÷��̾ �ν��Ͻ�ȭ, ����
    public static PlayerManager Instance{ get; private set; }
    public GameObject PlayerPrefab;
    public GameObject PlayerInstance { get; private set; }

    private void Awake()
    {   
        SpawnStart();
        if (Instance == null)
        {
            Instance = this;
        }

    }
    
    /// <summary>
    /// ���ϴ� ��ġ�� �÷��̾� ��ȯ
    /// </summary>
    /// <param name="SpawnPos"></param>
    public void SpawnPlayer(Vector3 SpawnPos)
    {
        // �� �Լ��� ����Ǹ�, ���� �����ִ� �÷��̾ �����ϰ� SpawnPos�� Spawn
        // ��� �� ��ȯ�̳� ���̵��� Ȱ��
        if(PlayerInstance != null)
        {
            Destroy(PlayerInstance);
        }
        PlayerInstance = Instantiate(PlayerPrefab,SpawnPos,Quaternion.identity);
    }
    /// <summary>
    /// 0,0,0�� ��ȯ
    /// </summary>
    public void SpawnStart()
    {
        // �׽�Ʈ������ 0,0,0 �� ��ȯ�ϴ� �뵵
        SpawnPlayer(Vector3.zero);
    }
}
