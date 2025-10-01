using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    [SerializeField] GameObject InteractionUIPref;
    List<Transform> InteractionObjs = new List<Transform>();
    List<GameObject> Keys = new List<GameObject>();
    Camera cam;

    private void Start()
    {
        cam = Camera.main;
        GameObject[] objs = GameObject.FindGameObjectsWithTag("InteractionObj");
        for (int i = 0; i < objs.Length; i++)
        {
            InteractionObjs.Add(objs[i].transform);
            GameObject InteractionKey = Instantiate(InteractionUIPref, objs[i].transform.position + new Vector3(0f,2.6f,-2.25f), Quaternion.identity, transform);
            Keys.Add(InteractionKey);
            Keys[i].SetActive(false);
        }
    }

    private void Update()
    {
        for (int i = 0; i < InteractionObjs.Count; i++)
        {
            if (InteractionObjs[i].GetComponent<NPCScript>().CanInteration)
            {
                Keys[i].SetActive(true);
            }
            else if (!InteractionObjs[i].GetComponent<NPCScript>().CanInteration)
            {
                Keys[i].SetActive(false);
            }
        }
    }


}
