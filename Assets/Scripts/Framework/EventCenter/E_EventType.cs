using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �¼����� ö��
/// </summary>
public enum E_EventType 
{
    /// <summary>
    /// ���������¼� ���� ������Monster
    /// </summary>
    E_Monster_Dead,
    /// <summary>
    /// ��һ�ȡ���� ���� ������int
    /// </summary>
    E_Player_GetReward,
    /// <summary>
    /// ��Ҹı�λ�á��� ������Vector3
    /// </summary>
    E_Player_ChangePos,
    /// <summary>
    /// �������¼� ���� ��������
    /// </summary>
    E_Test,
    /// <summary>
    /// �����л�ʱ���ȱ仯��ȡ
    /// </summary>
    E_SceneLoadChange,
    /// <summary>
    /// ɾ���ܲٳ����ϵ���Ʒ
    /// </summary>
    E_SceneDeleteItem,

    /// <summary>
    /// ����ϵͳ��������1 ��Ϊ
    /// </summary>
    E_Input_Skill1,
    /// <summary>
    /// ����ϵͳ��������2 ��Ϊ
    /// </summary>
    E_Input_Skill2,
    /// <summary>
    /// ����ϵͳ��������3 ��Ϊ
    /// </summary>
    E_Input_Skill3,

    /// <summary>
    /// ˮƽ�ȼ� -1~1���¼�����
    /// </summary>
    E_Input_Horizontal,

    /// <summary>
    /// ��ֱ�ȼ� -1~1���¼�����
    /// </summary>
    E_Input_Vertical,
    /// <summary>
    /// �����л��¼�
    /// </summary>
    E_KeyChange,
    /// <summary>
    /// �����л��������������� true����ȥfalse��
    /// </summary>
    E_Cg,
    /// <summary>
    /// ��ɫ�����ƶ�
    /// </summary>
    E_Input_Up,
    /// <summary>
    /// ��ɫ�����ƶ�
    /// </summary>
    E_Input_Down,
    /// <summary>
    /// ��ɫ�����ƶ�
    /// </summary>
    E_Input_Left,
    /// <summary>
    /// ��ɫ�����ƶ�
    /// </summary>
    E_Input_Right,
    /// <summary>
    /// ��ɫ2�����ƶ�
    /// </summary>
    E_P2_Input_Up,
    /// <summary>
    /// ��ɫ2�����ƶ�
    /// </summary>
    E_P2_Input_Down,
    /// <summary>
    /// ��ɫ2�����ƶ�
    /// </summary>
    E_P2_Input_Left,
    /// <summary>
    /// ��ɫ2�����ƶ�
    /// </summary>
    E_P2_Input_Right,
    /// <summary>
    /// ����𶯡�����������
    /// </summary>
    E_Camera_Shake,
    /// <summary>
    /// ��ɫ�л�����һ����Ʒ
    /// </summary>
    E_Input_NextObj,
    /// <summary>
    /// ��ɫ�л�����һ����Ʒ
    /// </summary>
    E_Input_BeforeObj,
    /// <summary>
    /// ������
    /// </summary>
    E_Panel_Update,
    /// <summary>
    /// �����ֵ��¼�����
    /// </summary>
    E_Input_MouseScroll,
}
