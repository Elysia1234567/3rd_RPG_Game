using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.Events;
using UnityEditor.Localization.Plugins.XLIFF.V12;

public class PlayerMgr : SingletonMono<PlayerMgr> 
{
    public int nowDays = 1;
    //��ǰ�ֳ����������ǰ�ֳ��������
    obj nowObj = new obj();
    public List<obj> objList = new List<obj>();
    int nowIndex = -1;//��ʼֵΪ-1����û����Ʒ
    //�¼�����
    UnityAction up;
    UnityAction down;
    UnityAction left;
    UnityAction right;
    UnityAction nextObj;
    UnityAction beforeObj;
    UnityAction keyChange;

    UnityAction<float> changeObj;


    int speed = 10;//�ƶ��ٶ�
    public GameObject RotaGameObj;//��ɫ������
    bool nowKey = true;//true����wasd��false������������
    private PlayerMgr()
    {
        //objList.Add(BinaryDataMgr.Instance.GetTable<objContainer>().dataDic[1]);
        //objList.Add(BinaryDataMgr.Instance.GetTable<objContainer>().dataDic[2]);
        //objList.Add(BinaryDataMgr.Instance.GetTable<objContainer>().dataDic[3]);
        //objList.Add(BinaryDataMgr.Instance.GetTable<objContainer>().dataDic[4]);
        //nowIndex = 0;
        //nowObj = objList[nowIndex];
        //Debug.Log(nowObj.name);
        addObj(BinaryDataMgr.Instance.GetTable<objContainer>().dataDic[1]);
        addObj(BinaryDataMgr.Instance.GetTable<objContainer>().dataDic[1]);
        addObj(BinaryDataMgr.Instance.GetTable<objContainer>().dataDic[1]);
        addObj(BinaryDataMgr.Instance.GetTable<objContainer>().dataDic[3]);
        addObj(BinaryDataMgr.Instance.GetTable<objContainer>().dataDic[2]);
        EventCenter.Instance.AddEventListener(E_EventType.E_Player_ChangePos, (Vector3 pos) =>
        {
            transform.parent.position = pos;
        });


    }
    // Start is called before the first frame update
    public void addObj(obj obj)
    {
        if (obj == null)
        {
            return;
        }
        if (nowIndex==-1)
        {
            objList.Add(obj);
            nowIndex = 0;
            nowObj = objList[nowIndex];
            EventCenter.Instance.EventTrigger(E_EventType.E_Panel_Update);
            return;
        }
        if (objList.Contains(obj)&&obj.isOverlay==1)
        {
            objList[objList.IndexOf(obj)].nowNum++;
            EventCenter.Instance.EventTrigger(E_EventType.E_Panel_Update);

            return;

        }
        objList.Add(obj);
        nowIndex = objList.IndexOf(nowObj);
        EventCenter.Instance.EventTrigger(E_EventType.E_Panel_Update);

    }
    public void removeObj(obj obj)
    {
        if (obj == null)
        {
            return;
        }
        objList.Remove(obj);
        nowIndex = objList.IndexOf(nowObj);
        if(objList.Count==0 )
        {
            nowIndex = -1;
        }
            EventCenter.Instance.EventTrigger(E_EventType.E_Panel_Update);

    }
    public void deleteOneObj(obj obj)//���ڿɵ�������ļ���
    {
        if (obj == null)
        {
            return;
        }
        if (objList.Contains(obj))
        {
            objList[objList.IndexOf(obj)].nowNum--;
            if (objList[objList.IndexOf(obj)].nowNum==0)
            {
                objList.Remove(obj);

            }
        }
        nowIndex = objList.IndexOf(nowObj);
        if (objList.Count == 0)
        {
            nowIndex = -1;
        }
        EventCenter.Instance.EventTrigger(E_EventType.E_Panel_Update);

    }
    private void KeyChange()
    {
        if (nowKey)
        {
            nowKey = false;
            InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_Input_Up, KeyCode.UpArrow, InputInfo.E_InputType.Always);
            InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_Input_Down, KeyCode.DownArrow, InputInfo.E_InputType.Always);
            InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_Input_Left, KeyCode.LeftArrow, InputInfo.E_InputType.Always);
            InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_Input_Right, KeyCode.RightArrow, InputInfo.E_InputType.Always);
            InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_P2_Input_Up, KeyCode.W, InputInfo.E_InputType.Always);
            InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_P2_Input_Down, KeyCode.S, InputInfo.E_InputType.Always);
            InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_P2_Input_Left, KeyCode.A, InputInfo.E_InputType.Always);
            InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_P2_Input_Right, KeyCode.D, InputInfo.E_InputType.Always);

            return;
        }
        if (!nowKey)
        {
            nowKey = true;
            InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_Input_Up, KeyCode.W, InputInfo.E_InputType.Always);
            InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_Input_Down, KeyCode.S, InputInfo.E_InputType.Always);
            InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_Input_Left, KeyCode.A, InputInfo.E_InputType.Always);
            InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_Input_Right, KeyCode.D, InputInfo.E_InputType.Always);
            InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_P2_Input_Up, KeyCode.UpArrow, InputInfo.E_InputType.Always);
            InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_P2_Input_Down, KeyCode.DownArrow, InputInfo.E_InputType.Always);
            InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_P2_Input_Left, KeyCode.LeftArrow, InputInfo.E_InputType.Always);
            InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_P2_Input_Right, KeyCode.RightArrow, InputInfo.E_InputType.Always);
            return;
        }
    }
    private void Up()
    {
        RotaGameObj.transform.Translate(speed * transform.up * Time.deltaTime);
        //�޸ĵķ�����ʹ��Rigidbody2D.MovePosition���������˶��������Ͳ�����ֶ���״��
        //float moveX = Input.GetAxisRaw("Horizontal");
        //float moveY = Input.GetAxisRaw("Vertical");
        //Vector2 p = this.transform.position;
        //p.x += moveX * speed * Time.deltaTime;
        //p.y += moveY * speed * Time.deltaTime;
        //this.transform.MovePosition(p);


    }
    private void Down()
    {
        RotaGameObj.transform.Translate(-speed * transform.up * Time.deltaTime);

    

    }
    private void Left()
    {
        RotaGameObj.transform.Translate(-speed * transform.right * Time.deltaTime);
      

    }
    private void Right()
    {
        RotaGameObj.transform.Translate(speed * transform.right * Time.deltaTime);
     

    }
    private void NextObj()
    {
        if (objList.Count == 0)
        {
            return;
        }

        nowIndex++;
        if (nowIndex >= objList.Count) { nowIndex = 0; }
        nowObj = objList[nowIndex];
        Debug.Log(nowObj.name);
        Debug.Log(nowObj.nowNum);

    }
    private void BeforeObj()
    {
        if (objList.Count == 0)
        {
            return;
        }

        nowIndex--;
        if (nowIndex < 0) { nowIndex=objList.Count - 1; }
        nowObj = objList[nowIndex];
        Debug.Log(nowObj.name);
        Debug.Log(nowObj.nowNum);

    }
    private void ChangeObj(float num)
    {
       //Debug.Log(num.ToString());
       if(num < 0)
        {
            NextObj();
        }
       if(num > 0)
        {
            BeforeObj();
        }
    }
    void Start()
    {

        //DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(RotaGameObj);

        InputMgr.Instance.StartOrCloseInputMgr(true);
        //�޸ģ���ʼ����λ���¼����ͣ��������¼��İ�ť������ʱ�������£�̧�𣬳�����
        InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_Input_Up, KeyCode.W, InputInfo.E_InputType.Always);
        InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_Input_Down, KeyCode.S, InputInfo.E_InputType.Always);
        InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_Input_Left, KeyCode.A, InputInfo.E_InputType.Always);
        InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_Input_Right, KeyCode.D, InputInfo.E_InputType.Always);
        InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_Input_NextObj, KeyCode.K, InputInfo.E_InputType.Down);
        InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_Input_BeforeObj, KeyCode.I, InputInfo.E_InputType.Down);
        InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_KeyChange, KeyCode.R, InputInfo.E_InputType.Down);

        up = new UnityAction(Up);
        down = new UnityAction(Down);
        left = new UnityAction(Left);
        right = new UnityAction(Right);
        nextObj = new UnityAction(NextObj);
        beforeObj = new UnityAction(BeforeObj);
        changeObj = new UnityAction<float>(ChangeObj);
        keyChange = new UnityAction(KeyChange);
        EventCenter.Instance.AddEventListener(E_EventType.E_Input_Up, up);
        EventCenter.Instance.AddEventListener(E_EventType.E_Input_Down, down);
        EventCenter.Instance.AddEventListener(E_EventType.E_Input_Left, left);
        EventCenter.Instance.AddEventListener(E_EventType.E_Input_Right, right);
        EventCenter.Instance.AddEventListener(E_EventType.E_Input_NextObj, nextObj);
        EventCenter.Instance.AddEventListener(E_EventType.E_Input_BeforeObj, beforeObj);
        EventCenter.Instance.AddEventListener(E_EventType.E_Input_MouseScroll, changeObj);
        EventCenter.Instance.AddEventListener(E_EventType.E_KeyChange, keyChange);




    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnDestroy()
    {
        EventCenter.Instance.RemoveEventListener(E_EventType.E_Input_Up, up);
        EventCenter.Instance.RemoveEventListener(E_EventType.E_Input_Down, down);
        EventCenter.Instance.RemoveEventListener(E_EventType.E_Input_Left, left);
        EventCenter.Instance.RemoveEventListener(E_EventType.E_Input_Right, right);
        EventCenter.Instance.RemoveEventListener(E_EventType.E_Input_NextObj, nextObj);
        EventCenter.Instance.RemoveEventListener(E_EventType.E_Input_BeforeObj, beforeObj);
        EventCenter.Instance.RemoveEventListener(E_EventType.E_Input_MouseScroll, changeObj);

    }
    /// <summary>
    /// ����TimeLine���õĽ�ֹ�ƶ�����
    /// </summary>
    public void DonMove()
    {
        InputMgr.Instance.StartOrCloseInputMgr(false);
    }
    /// <summary>
    /// ����TimeLine���õĻָ��ƶ�����
    /// </summary>
    public void CanMove()
    {
        InputMgr.Instance.StartOrCloseInputMgr(true);
    }

    public void ShowDialog(int id)
    {
        DialogMgr.Instance.isTimeLine = true;
        DialogMgr.Instance.ShowDialog(id);
    }

}
