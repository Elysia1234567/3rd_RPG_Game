using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMgr2 : SingletonMono<PlayerMgr2>
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
    UnityAction<float> changeObj;


    int speed = 10;//�ƶ��ٶ�
    public GameObject RotaGameObj;//��ɫ������
    private PlayerMgr2()
    {
        //objList.Add(BinaryDataMgr.Instance.GetTable<objContainer>().dataDic[1]);
        //objList.Add(BinaryDataMgr.Instance.GetTable<objContainer>().dataDic[2]);
        //objList.Add(BinaryDataMgr.Instance.GetTable<objContainer>().dataDic[3]);
        //objList.Add(BinaryDataMgr.Instance.GetTable<objContainer>().dataDic[4]);
        //nowIndex = 0;
        //nowObj = objList[nowIndex];
        //Debug.Log(nowObj.name);
        //EventCenter.Instance.AddEventListener(E_EventType.E_Player_ChangePos, (Vector3 pos) =>
        //{
        //    transform.parent.position = pos;
        //});


    }
    // Start is called before the first frame update
 
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
 
    void Start()
    {

        //DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(RotaGameObj);

        InputMgr.Instance.StartOrCloseInputMgr(true);
        //�޸ģ���ʼ����λ���¼����ͣ��������¼��İ�ť������ʱ�������£�̧�𣬳�����
        InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_P2_Input_Up, KeyCode.UpArrow, InputInfo.E_InputType.Always);
        InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_P2_Input_Down, KeyCode.DownArrow, InputInfo.E_InputType.Always);
        InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_P2_Input_Left, KeyCode.LeftArrow, InputInfo.E_InputType.Always);
        InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_P2_Input_Right, KeyCode.RightArrow, InputInfo.E_InputType.Always);

        up = new UnityAction(Up);
        down = new UnityAction(Down);
        left = new UnityAction(Left);
        right = new UnityAction(Right);
    
        EventCenter.Instance.AddEventListener(E_EventType.E_P2_Input_Up, up);
        EventCenter.Instance.AddEventListener(E_EventType.E_P2_Input_Down, down);
        EventCenter.Instance.AddEventListener(E_EventType.E_P2_Input_Left, left);
        EventCenter.Instance.AddEventListener(E_EventType.E_P2_Input_Right, right);
 


    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnDestroy()
    {
        EventCenter.Instance.RemoveEventListener(E_EventType.E_P2_Input_Up, up);
        EventCenter.Instance.RemoveEventListener(E_EventType.E_P2_Input_Down, down);
        EventCenter.Instance.RemoveEventListener(E_EventType.E_P2_Input_Left, left);
        EventCenter.Instance.RemoveEventListener(E_EventType.E_P2_Input_Right, right);
   

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
