using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using UnityEngine;

public class TargetingScript : MonoBehaviour
{
    protected Transform target;

    void OnEnable()
    {
        if(PlayerManager.Instance != null)
        {
            PlayerManager.Instance.OnPlayerSpawned.AddListener(OnPlayerSapwnedHandler);
        }
    }

    private void OnDisable()
    {
        if(PlayerManager.Instance != null)
        {
            PlayerManager.Instance.OnPlayerSpawned.RemoveListener(OnPlayerSapwnedHandler);
        }
    }


    protected virtual void OnPlayerSapwnedHandler(Transform newPlayerTransform)
    {
        target = newPlayerTransform;
        Debug.Log("새로운 플레이어 감지");
    }

}
