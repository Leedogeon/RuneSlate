using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // �÷��̾��� ��ǲ������ ��� ó���� ���⼭ �ۼ�
    // �ڼ��� �ڵ�� �ش��ϴ� ��ũ��Ʈ���� �ۼ�
    public Vector2 MoveInput { get; private set; }
    public bool AttackInput { get; private set; }

    // Update is called once per frame
    void Update()
    {
        // �밢�� �̵��Ÿ� ������ ���� normalized�� ��ǲ���� ó��
        //MoveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        // �����¿� �Է�Ű���� ���氡���ϰ� ��������� ����
        MoveInput = MoveInput_CanChange();
        
        // ������ ���콺 ��Ŭ������ ����
        // ���ݵ��߿� ȸ���� �������� �ӽ÷� GetMoustButton���� ����, ���� ���ݸ�� �������� �����ϴ� ������ ����
        //AttackInput = Input.GetMouseButton(0);
        // �Է°���ȭ�� ���� KeyManger�� ����� Ȱ��
        AttackInput = Input.GetKeyDown(KeySetting.keys[KeyAction.ATTACK]);
    }

    /// <summary>
    /// WASD �����¿� �Էµ� ���氡���ϰ� �����α� ���ؼ� ����
    /// </summary>
    /// <returns></returns>
    public static Vector2 MoveInput_CanChange()
    {
        Vector2 move = Vector2.zero;

        if (Input.GetKey(KeySetting.keys[KeyAction.UP]))
            move.y += 1;
        if (Input.GetKey(KeySetting.keys[KeyAction.DOWN]))
            move.y -= 1;
        if (Input.GetKey(KeySetting.keys[KeyAction.RIGHT]))
            move.x += 1;
        if (Input.GetKey(KeySetting.keys[KeyAction.LEFT]))
            move.x -= 1;

        return move.normalized;
    }
}
