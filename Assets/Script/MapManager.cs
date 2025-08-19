using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public Transform SpawnPoint;
    [SerializeField] private GameObject prologue;
    public bool CanInteraction = false;
    [SerializeField] private GameObject OptionPanel;
    [SerializeField] private GameObject HPUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // mapManager의 invisivleObj을 이용하여 처리
            invisivleObj(OptionPanel);
            // 속도증감, 0 -> 정지
            Time.timeScale = CanInteraction ? 1 : 0;
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
        CanInteraction = isAct;
    }


}
