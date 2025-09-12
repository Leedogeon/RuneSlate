using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public Transform SpawnPoint;
    public Transform NextPos;
    [SerializeField] private GameObject prologue;
    public bool CanInteraction = false;
    [SerializeField] private GameObject OptionPanel;
    [SerializeField] private GameObject HPUI;
    [SerializeField] private GameObject SaveLoadPanel;
    [SerializeField] private GameObject TalkUI;
    public bool IsSaveLoadOpen = false;

    [SerializeField] public Vector3 ElitePos;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!IsSaveLoadOpen)
            {
                // mapManager의 invisivleObj을 이용하여 처리
                invisivleObj(OptionPanel);
                // 속도증감, 0 -> 정지
                Time.timeScale = CanInteraction ? 1 : 0;
            }
            else
            {
                invisivleObj(SaveLoadPanel);
            }

        }       

    }

    // 다른 Obj들에게도 적용하기위해 변경 - 08.01
    public void invisivleObj(GameObject obj)
    {
        if (obj.name == "Prologue") HPUI.SetActive(true);
        if (obj == null) return;
        // 현재 obj의 활성화 상태를 이용
        bool isAct = obj.activeSelf;
        obj.SetActive(!isAct);
        if(obj.name == "PauseMenu" || obj.name == "Prologue")
            CanInteraction = isAct;
        if (obj.name == "SaveLoadPanel")
        {
            Debug.Log("SaveLoadOpen");
            IsSaveLoadOpen = false;
        }
    }

    public void TempStartTalk()
    {
        StartCoroutine(Test());
    }
    IEnumerator Test()
    {
        yield return new WaitForSeconds(1f);
        TalkUI.SetActive(true);
    }

}
