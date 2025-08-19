using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // 여기서 플레이어를 인스턴스화, 관리
    public static PlayerManager Instance{ get; private set; }
    public GameObject PlayerPrefab;
    public GameObject PlayerInstance { get; private set; }

    public MapManager mapManager;
    public Transform SpawnPoint;
    public GameObject Test;

    public SaveLoad saveload;
    private void Awake()
    {   
        mapManager = FindObjectOfType<MapManager>();
        saveload = FindObjectOfType<SaveLoad>();
        
        SpawnStart();
        if (Instance == null)
        {
            Instance = this;
        }
        // 로드할 플레이어를 PlayerInstance로 변경
        if (saveload)
        {
            saveload.player = PlayerInstance;
            //saveload.LoadGame();
            // 임시로 0번파일로 지정
            saveload.LoadFromFile(0);
        }
    }
    

    /// <summary>
    /// 원하는 위치에 플레이어 소환
    /// </summary>
    /// <param name="SpawnPos"></param>
    public void SpawnPlayer(Vector3 SpawnPos)
    {
        // 이 함수가 실행되면, 현재 남아있는 플레이어를 삭제하고 SpawnPos에 Spawn
        // 사망 후 소환이나 맵이동시 활용
        if(PlayerInstance != null)
        {
            Destroy(PlayerInstance);
        }
        PlayerInstance = Instantiate(PlayerPrefab,SpawnPos,Quaternion.identity);

    }
    /// <summary>
    /// 0,0,0에 소환
    /// </summary>
    public void SpawnStart()
    {
        if(mapManager != null)
        {
            SpawnPlayer(mapManager.SpawnPoint.position);
        }
        // 테스트용으로 0,0,0 에 소환하는 용도
        else SpawnPlayer(Vector3.zero);

    }

    public void effectSpawn()
    {
        Vector3 effectPos = PlayerInstance.transform.position + new Vector3(0, 2, 0);
        GameObject effect1 = Instantiate(Test, effectPos, Quaternion.Euler(-180, 0, 0));

        Destroy(effect1, 1f);
    }
}
