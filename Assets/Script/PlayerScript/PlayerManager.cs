using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;


// event로 플레이어가 소환될때 다른 스크립트에 자동 적용하기위해 변경
// 다른 스크립트들에서 플레이어 적용방식 변경
[System.Serializable]
//public class PlayerSpawnEvent : UnityEvent<Transform> { }
public class PlayerManager : MonoBehaviour
{

    // 여기서 플레이어를 인스턴스화, 관리
    public static PlayerManager Instance { get; private set; }
    public GameObject PlayerPrefab;
    public GameObject PlayerInstance { get; private set; }

    //public PlayerSpawnEvent OnPlayerSpawned = new PlayerSpawnEvent();
    public Vector3 SpawnPoint;
    public GameObject Test;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
/*        else
        {
            Destroy(gameObject);
            return;
        }*/

        if(PlayerDataControll.PlayerStartPosFromLoad != Vector3.zero)
        {
            SpawnPoint = PlayerDataControll.PlayerStartPosFromLoad;
        }

        SpawnStart();
    }
    /// <summary>
    /// 원하는 위치에 플레이어 소환
    /// </summary>
    /// <param name="SpawnPos"></param>
    public void SpawnPlayer(Vector3 SpawnPos)
    {
        // 이 함수가 실행되면, 현재 남아있는 플레이어를 삭제하고 SpawnPos에 Spawn
        // 사망 후 소환이나 맵이동시 활용
        if (PlayerInstance != null)
        {
            Destroy(PlayerInstance);
        }
        PlayerInstance = Instantiate(PlayerPrefab, SpawnPos, Quaternion.identity);
        //OnPlayerSpawned.Invoke(PlayerInstance.transform);
    }
    /// <summary>
    /// 0,0,0에 소환
    /// </summary>
    public void SpawnStart()
    {
        SpawnPlayer(SpawnPoint);
    }

    public void effectSpawn()
    {
        Vector3 effectPos = PlayerInstance.transform.position + new Vector3(0, 2, 0);
        GameObject effect1 = Instantiate(Test, effectPos, Quaternion.Euler(-180, 0, 0));

        Destroy(effect1, 1f);
    }

    public void TestSpawn()
    {
        Destroy(PlayerInstance);

        SpawnPlayer(SpawnPoint);
    }

    private void Update()
    {
    }
}
