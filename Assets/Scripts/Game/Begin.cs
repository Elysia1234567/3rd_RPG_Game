using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Begin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //transform.DOShakePosition(1, 2);

        //Ui管理器来控制面板的显示和隐藏，拼好的面板记得放在editor里的艺术资源文件夹的ui里
        UIMgr.Instance.ShowPanel<BeginPanel>(E_UILayer.System);
        UIMgr.Instance.ShowPanel<ChangePanel>(E_UILayer.Animation);


        //将表中内容存入
        BinaryDataMgr.Instance.LoadTable<DialogInfoContainer, DialogInfo>();
        //开启输入检测
        //InputMgr.Instance.StartOrCloseInputMgr(true);
        ////修改，初始化键位，事件类型，触发该事件的按钮，触发时机（按下，抬起，长按）
        //InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_Input_Up, KeyCode.W, InputInfo.E_InputType.Down);
        //InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_Input_Down, KeyCode.S, InputInfo.E_InputType.Down);
        //InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_Input_Left, KeyCode.A, InputInfo.E_InputType.Down);
        //InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_Input_Right, KeyCode.D, InputInfo.E_InputType.Down);



        //播放背景音乐
        MusicMgr.Instance.PlayBKMusic("Begin");
        //二进制数据持久化，按照配置要求写好表哥，然后在BDM中自动生成数据结构类以及把表格信息转换为二进制信息
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
