using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SceneManager 사용을위해
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject OptionTap;
    public void GameStart()
    {
        SceneManager.LoadSceneAsync("SampleScene");
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
