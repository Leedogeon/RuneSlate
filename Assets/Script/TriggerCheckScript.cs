using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerCheckScript : MonoBehaviour
{
    [SerializeField] TriggerScript triggerScript;
    [SerializeField] int UIIndex;
    [SerializeField] GameObject Knights;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
            triggerScript.OnChildTrigger(gameObject, UIIndex);
        Destroy(Knights);
    }
}
