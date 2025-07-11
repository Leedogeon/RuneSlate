using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerInput Input;
    Rigidbody Rigid;
    [SerializeField] public float speed = 5f;

    private void Awake()
    {
        Input = GetComponent<PlayerInput>();
        Rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 dir = new Vector3(Input.MoveInput.x,0,Input.MoveInput.y);
        Rigid.MovePosition(transform.position + dir * speed * Time.fixedDeltaTime);
    }
}
