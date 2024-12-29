using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : MonoBehaviour
{
    //玩家当前移动方向
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
        //需要保留父类Update的执行 因为之后 父类当中也可能处理相关内容
        //base.Update();

        //通过移动方向是否为000，来改变动画切换条件 是否为移动
        //animator.SetBool("isMoving", _moveDir != Vector3.zero);

        if (_moveDir != Vector3.zero)
        {
            //Debug.Log(GetProperty<PlayerProperty>().turnAroundSpeed);
            //Debug.Log(GetProperty<PlayerProperty>().moveSpeed);

            //进行转向
            //rootTransform.rotation = Quaternion.Slerp(rootTransform.rotation, //当前的角度信息
            //                                           Quaternion.LookRotation(_moveDir.normalized), //目标角度信息
            //                                           GetProperty<PlayerProperty>().turnAroundSpeed * Time.deltaTime);//转身速度
            //进行移动
            transform.Translate(Vector3.forward * speed * Time.deltaTime);//移动方向*移动速度*移动时间
        }
    }

    /// <summary>
    /// 开启或者关闭 玩家的输入监听
    /// </summary>
    /// <param name="isOpen">ture表示开启，false表示关闭</param>
    public void OpenOrCloseInputEventListener(bool isOpen)
    {
        if (isOpen)
        {
            //开启输入监听
            EventCenter.Instance.AddEventListener<float>(E_EventType.E_Input_Horizontal, ChangeMoveX);
            EventCenter.Instance.AddEventListener<float>(E_EventType.E_Input_Vertical, ChangeMoveZ);
        }
        else
        {
            //关闭输入监听
            EventCenter.Instance.RemoveEventListener<float>(E_EventType.E_Input_Horizontal, ChangeMoveX);
            EventCenter.Instance.RemoveEventListener<float>(E_EventType.E_Input_Vertical, ChangeMoveZ);
        }
    }

    /// <summary>
    /// 改变移动方向的x轴向
    /// </summary>
    /// <param name="value"></param>
    private void ChangeMoveX(float value)
    {
        _moveDir.x = value;
    }

    /// <summary>
    /// 改变移动方向的z轴向
    /// </summary>
    /// <param name="value"></param>
    private void ChangeMoveZ(float value)
    {
        _moveDir.z = value;
    }

}
