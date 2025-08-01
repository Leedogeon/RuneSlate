using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class SaveLoad : MonoBehaviour
{
   
    [SerializeField] public GameObject player;



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

    public void SaveToFile(int slot)
    {
        SaveData data = new SaveData();
        data.playerX = player.transform.position.x;
        data.playerY = player.transform.position.y;
        data.playerZ = player.transform.position.z;
        // 임시 데이터
        data.hp = 100;
        data.level = 5;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(GetPath(slot), json);

        Debug.Log("Saved to: " + GetPath(slot));
    }

    public void LoadFromFile(int slot)
    {
        string path = GetPath(slot);
        // 저장된 파일이 없다면 return
        if (!File.Exists(path))
        {
            Debug.LogWarning("Save file not found: " + path);
            return;
        }

        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        // 저장된 위치로 플레이어 이동
        player.transform.position = new Vector3(data.playerX, data.playerY, data.playerZ);
        Debug.Log("Loaded from: " + path);
    }

    private string GetPath(int slot)
    {
        return Application.persistentDataPath + $"/save{slot}.json";
    }

    #endregion
}
