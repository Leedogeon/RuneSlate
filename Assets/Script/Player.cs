using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInput Input { get; private set; }
    public PlayerMovement Movement { get; private set; }

    private void Awake()
    {
        Input = GetComponent<PlayerInput>();
        Movement = GetComponent<PlayerMovement>();
    }

    void Start()
    {
    }
    void Update()
    {
        if(Input.AttackInput)
        {
            Debug.Log("test");
        }
    }
}
