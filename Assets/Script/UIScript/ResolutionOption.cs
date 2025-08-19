using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResolutionOption : MonoBehaviour
{
    [SerializeField]GameObject OptionTap;
    public CanvasGroup self;
    FullScreenMode screenMode;
    public Toggle fullscreenBtn;
    public TMP_Dropdown resolutionDropdown;
    List<Resolution> resolutions = new List<Resolution>();
    int resolutionIndex = 0;


    private void Start()
    {

        /*        resolutionDropdown = GetComponentInChildren<TMP_Dropdown>();*/
        InitUI();
    }
    void InitUI()
    {
        /*        resolutions.AddRange(Screen.resolutions);
                // 지원가능 해상도 디버그
                foreach (Resolution item in Screen.resolutions)
                {
                    Debug.Log(item.width + "x" + item.height + " " + item.refreshRateRatio);
                }*/

        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            if (Screen.resolutions[i].refreshRateRatio.value >= 60 && Screen.resolutions[i].width >= 960)
            {
                resolutions.Add(Screen.resolutions[i]);
            }
        }
        // 기존 Dropdown 요소들 제거
        resolutionDropdown.options.Clear();
        int optionNum = 0;
        foreach (Resolution item in resolutions)
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData();
            option.text = item.width + " x " + item.height + " " + item.refreshRateRatio + "hz";
            resolutionDropdown.options.Add(option);
            if (item.width == Screen.width && item.height == Screen.height)
                resolutionDropdown.value = optionNum;
            optionNum++;

        }
        // 새로고침
        resolutionDropdown.RefreshShownValue();

        fullscreenBtn.isOn = Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow) ? true : false;
    }

    public void FindDropDown()
    {

        resolutionDropdown = GetComponentInChildren<TMP_Dropdown>();
    }
    public void DropBoxOptionChange(int x)
    {
        resolutionIndex = x;
        Debug.Log(resolutionIndex);
    }
    public void FullScreenBtn(bool isFull)
    {
        screenMode = fullscreenBtn.isOn ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
    }
    public void retrunBtn()
    {
        Screen.SetResolution(resolutions[resolutionIndex].width, resolutions[resolutionIndex].height, screenMode);
        OptionTap.SetActive(false);
    }
}
