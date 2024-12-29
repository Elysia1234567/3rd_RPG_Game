using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : MonoBehaviour
{
    //��ҵ�ǰ�ƶ�����
    private Vector3 _moveDir;

    //public override void InitObj(params int[] ids)
    //{

    //}
    public void Start()
    {
        OpenOrCloseInputEventListener(true);
    }
    public int speed = 10;
    protected void Update()
    {
        //��Ҫ��������Update��ִ�� ��Ϊ֮�� ���൱��Ҳ���ܴ����������
        //base.Update();

        //ͨ���ƶ������Ƿ�Ϊ000�����ı䶯���л����� �Ƿ�Ϊ�ƶ�
        //animator.SetBool("isMoving", _moveDir != Vector3.zero);

        if (_moveDir != Vector3.zero)
        {
            //Debug.Log(GetProperty<PlayerProperty>().turnAroundSpeed);
            //Debug.Log(GetProperty<PlayerProperty>().moveSpeed);

            //����ת��
            //rootTransform.rotation = Quaternion.Slerp(rootTransform.rotation, //��ǰ�ĽǶ���Ϣ
            //                                           Quaternion.LookRotation(_moveDir.normalized), //Ŀ��Ƕ���Ϣ
            //                                           GetProperty<PlayerProperty>().turnAroundSpeed * Time.deltaTime);//ת���ٶ�
            //�����ƶ�
            transform.Translate(Vector3.forward * speed * Time.deltaTime);//�ƶ�����*�ƶ��ٶ�*�ƶ�ʱ��
        }
    }

    /// <summary>
    /// �������߹ر� ��ҵ��������
    /// </summary>
    /// <param name="isOpen">ture��ʾ������false��ʾ�ر�</param>
    public void OpenOrCloseInputEventListener(bool isOpen)
    {
        if (isOpen)
        {
            //�����������
            EventCenter.Instance.AddEventListener<float>(E_EventType.E_Input_Horizontal, ChangeMoveX);
            EventCenter.Instance.AddEventListener<float>(E_EventType.E_Input_Vertical, ChangeMoveZ);
        }
        else
        {
            //�ر��������
            EventCenter.Instance.RemoveEventListener<float>(E_EventType.E_Input_Horizontal, ChangeMoveX);
            EventCenter.Instance.RemoveEventListener<float>(E_EventType.E_Input_Vertical, ChangeMoveZ);
        }
    }

    /// <summary>
    /// �ı��ƶ������x����
    /// </summary>
    /// <param name="value"></param>
    private void ChangeMoveX(float value)
    {
        _moveDir.x = value;
    }

    /// <summary>
    /// �ı��ƶ������z����
    /// </summary>
    /// <param name="value"></param>
    private void ChangeMoveZ(float value)
    {
        _moveDir.z = value;
    }

}
