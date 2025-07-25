using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SceneManager 사용을위해
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }
    public void Option()
    {

    }

    public void Exit()
    {
        // 종료
        Application.Quit();
    }
}
