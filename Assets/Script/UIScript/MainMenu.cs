using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SceneManager ���������
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
        // ����
        Application.Quit();
    }
}
