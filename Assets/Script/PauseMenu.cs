using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject OptionPannel;
    [SerializeField] private SaveLoad saveload;
    //[SerializeField] private GameObject player;
    MapManager mapManager;
    public bool OptionOpened = false;

    public Button[] menuButtons;
    private int selectIndex = 0;
    private GraphicRaycaster raycaster;
    private EventSystem eventSystem;

    private void Awake()
    {
        mapManager = FindObjectOfType<MapManager>();
        raycaster = FindObjectOfType<GraphicRaycaster>();
        saveload = FindObjectOfType<SaveLoad>();
    }
    private void Update()
    {
        // 처음 열면 0번 인덱스 활성화 - 미완성상태
        MoveSelection(0);

        // 마우스 포인터 위치를 활성화시키기 위한 부분 - 미완성
        PointerEventData pointerData = new PointerEventData(eventSystem);
        pointerData.position = Input.mousePosition;

        // 마우스 포인터위치에 있는 UI들만 들어감
        // 이미지 컴퍼넌트가 있어야 해당되지만 이미지 컴퍼넌트에 Raycast Target을 false로 하면 무시됨 
        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(pointerData, results);

        foreach (RaycastResult result in results)
        {
            // 마우스가 올라간 버튼이 menuButtons에 있는지 체크
            int newIndex = Array.FindIndex(menuButtons, btn => btn.gameObject == result.gameObject);

            // 버튼 위가 아닐경우 return해야해서 -1 필요함
            if (newIndex != -1 && newIndex != selectIndex)
            {
                // 이부분은 MoveSelection, Index_MouseOnButton 부분을 조정하고 함수 하나로 합쳐야됨
                menuButtons[selectIndex].GetComponent<Image>().color = Color.white;
                selectIndex = newIndex;
                menuButtons[selectIndex].GetComponent<Image>().color = Color.green;
                break;
            }
        }

        //키보드 좌,우 방향키 작동시 좌우 이동
        // 키다운시 연속처리되는것 추가할지 고민중
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveSelection(1);
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveSelection(-1);
        }
        
    }

    public void MoveSelection(int dir)
    {
        menuButtons[selectIndex].GetComponent<Image>().color = Color.white;
        //좌우 이동시에는 범위를 벗어나면 체크해줘야 할 필요가 있음
        selectIndex = (selectIndex + dir + menuButtons.Length) % menuButtons.Length;
        menuButtons[selectIndex].GetComponent<Image>().color = Color.green;
    }
    public void Index_MouseOnButton(int curIndex)
    {
        if (selectIndex == curIndex) return;

        menuButtons[selectIndex].GetComponent<Image>().color = Color.white;
        selectIndex = curIndex;
        menuButtons[selectIndex].GetComponent<Image>().color = Color.green;
    }

    // 세이브 로드
    public void OpenSaveLoad(bool isSave)
    {
        Debug.Log(isSave + "curIndex = " + selectIndex);
        // isSave가 true이면 세이브, false면 로드
        // saveload의 player를 현재 PlayerInstance로 수정하고 저장
        if (isSave)
        {
            saveload.player = PlayerManager.Instance.PlayerInstance;
            saveload.SaveToFile(0);
        }
        else
        {
            saveload.player = PlayerManager.Instance.PlayerInstance;
            saveload.LoadFromFile(0);
        }
    }

    public void ResolutionOpen()
    {
        Debug.Log("res");
        OptionPannel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
