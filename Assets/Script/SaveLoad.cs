using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
// static으로 관리하는것이 편할것으로 예상되어 static으로 변경
// 오류나는 부분 수정중
public static class SaveLoad
{
    /*    #region 레지스트리식 저장
        // 플레이어의 X,Y,Z값 저장
        public void SaveGame()
        {
            Debug.Log("SAVE");
            PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
            PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
            PlayerPrefs.SetFloat("PlayerZ", player.transform.position.z);
            PlayerPrefs.Save();

        }

        public void LoadGame()
        {
            // 저장한 기록이 없는경우 리턴
            if (!PlayerPrefs.HasKey("PlayerX")) return;
            // 플레이어가 비어있는경우 리턴 -> 이부분은 플레이어가 존재할때까지 체크하는것으로 변경해야됨
            if (!player) return;
            float x = PlayerPrefs.GetFloat("PlayerX");
            float y = PlayerPrefs.GetFloat("PlayerY");
            float z = PlayerPrefs.GetFloat("PlayerZ");
            player.transform.position = new Vector3(x, y, z);
        }
        #endregion*/


    #region JSON저장
    // 현재 미완성, 파일을 0번으로 지정하여 0번만 사용중

    public static void SaveToFile(int slot,Vector3 PlayerPos)
    {
        SaveData data = new SaveData();
        data.playerX = PlayerPos.x;
        data.playerY = PlayerPos.y;
        data.playerZ = PlayerPos.z;
        // 임시 데이터
        data.hp = 100;
        data.level = 5;

        // 파일이 첫시작인지 체크
        data.isStart = true;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(GetPath(slot), json);

        Debug.Log("Saved to: " + GetPath(slot));
    }


    public static bool LoadFromFile(int slot)
    {
        string path = GetPath(slot);
        // 저장된 파일이 없다면 return
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (!File.Exists(path))
        {
            if (currentSceneName == "MainMenu")
            {
                SceneManager.LoadSceneAsync("RuneSlate_Tutorial_Map");
                return false;
            }

                Debug.LogWarning("Save file not found: " + path);
            return false;
        }

        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        // 필요한 데이터 저장
        Debug.Log($"X = {data.playerX} , Y = {data.playerY}, Z = {data.playerZ}");

        PlayerDataControll.PlayerStartPosFromLoad = new Vector3(data.playerX, data.playerY, data.playerZ);
        PlayerDataControll.BaseHp = data.hp;
        PlayerDataControll.Lv = data.level;
        PlayerDataControll.PlayTime = data.playTime;
        PlayerDataControll.IsFileStart = data.isStart;

        // 인스턴스가 있는상태라면 이동 -> 추가해야됨
        if(currentSceneName != "MainMenu")
        {
            if (PlayerManager.Instance.PlayerInstance != null)
                PlayerManager.Instance.PlayerInstance.transform.position = new Vector3(data.playerX, data.playerY, data.playerZ);
        }
        
        Debug.Log("Loaded from: " + path);
        return true;
    }

    public static string GetPath(int slot)
    {
        return Application.persistentDataPath + $"/save{slot}.json";
    }

    #endregion
}
