using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadButton : MonoBehaviour
{
    public bool IsSave = true;
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private GameObject[] IsEmptySlot;
    [SerializeField] private GameObject[] DataSlot;
    private void Awake()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();
        UpdateSlot();
    }

    // 슬롯 갱신 - save나 delete의 경우 지정 슬롯만 업데이트, 파라미터가 없을경우 전체 업데이트
    private void UpdateSlot()
    {
        for (int i = 0; i < IsEmptySlot.Length; i++)
        {
            if (IsFileEmpty(i))
            {
                DataSlot[i].SetActive(true);
                IsEmptySlot[i].SetActive(false);
            }

            else
            {
                DataSlot[i].SetActive(false);
                IsEmptySlot[i].SetActive(true);
            }
        }
    }
    private void UpdateSlot(int index)
    {

        if (IsFileEmpty(index))
        {
            DataSlot[index].SetActive(true);
            IsEmptySlot[index].SetActive(false);
        }

        else
        {
            DataSlot[index].SetActive(false);
            IsEmptySlot[index].SetActive(true);
        }

    }


    public void SaveOrLoad(int index)
    {
        if (IsSave) SaveFile(index);
        else LoadFile(index);
    }

    // 패널 닫는건 pauseMenu에서 처리

    public void SaveFile(int index)
    {
        pauseMenu.SaveFile(index);
        UpdateSlot(index);
    }
/*    public void LoadFile(int index)
    {
        pauseMenu.LoadFile(index);
    }*/

    // 이부분은 모든 씬에서 공동으로 활용
    public void LoadFile(int Index)
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SaveLoad.LoadFromFile(Index);
        Debug.Log("index = " + Index);
        // savepanel 닫기
        // mapManager.invisivleObj(savepanel); ==> 어디에서 해도 적용되도록 변경해야됨
        gameObject.SetActive(false); // => 게임씬에 적용될 다른부분 mapManger에서 오류없는지 체크해야됨
        
        // 임시처리부분
        MapManager manager = FindObjectOfType<MapManager>();
        if (manager != null)
        {
            manager.IsSaveLoadOpen = false;
        }
        if(currentSceneName == "RuneSlate_MainMenu")
        {
            SceneManager.LoadSceneAsync("RuneSlate_Tutorial_Map");
        }
    }

    public void DeleteFile(int index)
    {
        string path = SaveLoad.GetPath(index);

        if (File.Exists(path))
        {
            // 파일 삭제
            File.Delete(path);
            UnityEngine.Debug.Log("세이브 파일이 삭제되었습니다: " + path);
            UpdateSlot(index);
        }
        else
        {
            UnityEngine.Debug.Log("삭제할 세이브 파일이 없습니다: " + path);
        }
        gameObject.SetActive(false);
    }

    // empty한지 체크하여 (빈슬롯) 텍스트를 출력할지, 데이터를 출력할지
    public bool IsFileEmpty(int index)
    {
        // 스태틱 사용
        string path = SaveLoad.GetPath(index);
        // 저장된 파일이 없다면 return
        if (!File.Exists(path))
        {
            return false;
        }
        return true;
    }
}
