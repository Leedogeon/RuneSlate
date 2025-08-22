using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SceneManager 사용을위해
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject OptionTap;
    [SerializeField] GameObject saveload;
    [SerializeField] SaveLoadButton saveloadbtn;
    private void Awake()
    {
        if(saveloadbtn == null)
        saveloadbtn = GetComponentInChildren<SaveLoadButton>();
    }
    public void GameStart()
    {
        saveloadbtn.IsSave = false;
        saveload.SetActive(true);
        // 수정해서 값 넣어줘야함 --> saveloadbtn으로?
        //SaveLoad.LoadFromFile(0);

        //SceneManager.LoadSceneAsync("SampleScene");
    }

    public void Option()
    {
        OptionTap.SetActive(true);
    }
    public void Exit()
    {
        // 종료
        Application.Quit();
    }
}
