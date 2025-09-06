using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    [SerializeField] GameObject[] Triggers;
    [SerializeField] GameManager gameManager;

    public void OnChildTrigger(GameObject children, int UIIndex)
    {
        Debug.Log(children.ToString());
        if (Triggers[0] == children)
        {
            Debug.Log(children.name);
            gameManager.TalkUI(UIIndex);
            children.gameObject.SetActive(false);
        }
        if(Triggers[1] == children)
        {
            gameManager.QuestOpen();
            Debug.Log(children.name);
            children.gameObject.SetActive(false);
        }
    }
}
