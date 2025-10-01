using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{

    [SerializeField] GameObject HpBarPrefab;

    List<Transform> objList = new List<Transform>();
    [SerializeField]List<GameObject> hpBarList = new List<GameObject>();
    [SerializeField] List<float> curHp = new List<float>();
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = 0; i < objects.Length; i++)
        {
            objList.Add(objects[i].transform);
            GameObject hpBars = Instantiate(HpBarPrefab,objects[i].transform.position,Quaternion.identity,transform);
            hpBarList.Add(hpBars);
            curHp.Add(objList[i].GetComponent<Enemy>().Hp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = objList.Count - 1; i >= 0; i--) // 뒤에서부터 지워야 안전
        {
            if (objList[i].GetComponent<Enemy>().Hp <=0) // 적이 Destroy된 경우
            {
                Destroy(hpBarList[i]);     // hp바 제거
                objList.RemoveAt(i);       // 리스트에서 제거
                hpBarList.RemoveAt(i);
                curHp.RemoveAt(i);
                continue;
            }
            Enemy enemy = objList[i].GetComponent<Enemy>();
            float ratio = enemy.Hp / enemy.maxHp;
            // 살아있는 경우만 위치 갱신
            hpBarList[i].transform.position = cam.WorldToScreenPoint(objList[i].position + new Vector3(0, 1, 0));
            hpBarList[i].transform.Find("HP").GetComponent<Image>().fillAmount = ratio;
        }
    }
}
