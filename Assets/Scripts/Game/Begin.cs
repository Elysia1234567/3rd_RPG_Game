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

        //Ui������������������ʾ�����أ�ƴ�õ����ǵ÷���editor���������Դ�ļ��е�ui��
        UIMgr.Instance.ShowPanel<BeginPanel>(E_UILayer.System);
        UIMgr.Instance.ShowPanel<ChangePanel>(E_UILayer.Animation);


        //���������ݴ���
        BinaryDataMgr.Instance.LoadTable<DialogInfoContainer, DialogInfo>();
        //����������
        //InputMgr.Instance.StartOrCloseInputMgr(true);
        ////�޸ģ���ʼ����λ���¼����ͣ��������¼��İ�ť������ʱ�������£�̧�𣬳�����
        //InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_Input_Up, KeyCode.W, InputInfo.E_InputType.Down);
        //InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_Input_Down, KeyCode.S, InputInfo.E_InputType.Down);
        //InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_Input_Left, KeyCode.A, InputInfo.E_InputType.Down);
        //InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_Input_Right, KeyCode.D, InputInfo.E_InputType.Down);



        //���ű�������
        MusicMgr.Instance.PlayBKMusic("Begin");
        //���������ݳ־û�����������Ҫ��д�ñ�磬Ȼ����BDM���Զ��������ݽṹ���Լ��ѱ����Ϣת��Ϊ��������Ϣ
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
