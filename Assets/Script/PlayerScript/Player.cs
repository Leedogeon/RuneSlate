using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // �ٸ� ��ũ��Ʈ���� �Է°��� �������� ������, ������ �Ұ����ϰ� ĸ��ȭ
    // �ڵ带 ������ ������
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
        // ���� ��ǲ �׽�Ʈ��
        if(Input.AttackInput)
        {
            Debug.Log("Attack_Main");
        }
    }
}
