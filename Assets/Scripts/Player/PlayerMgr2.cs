using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMgr2 : SingletonMono<PlayerMgr2>
{
    public int nowDays = 1;
    //当前手持物，背包，当前手持物的索引
    obj nowObj = new obj();
    public List<obj> objList = new List<obj>();
    int nowIndex = -1;//初始值为-1代表没有物品
    //事件监听
    UnityAction up;
    UnityAction down;
    UnityAction left;
    UnityAction right;
    UnityAction nextObj;
    UnityAction beforeObj;
    UnityAction<float> changeObj;


    int speed = 10;//移动速度
    public GameObject RotaGameObj;//角色根物体
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
        //修改的方法是使用Rigidbody2D.MovePosition§来进行运动。这样就不会出现抖动状况
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
        //修改，初始化键位，事件类型，触发该事件的按钮，触发时机（按下，抬起，长按）
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
    /// 用于TimeLine调用的禁止移动方法
    /// </summary>
    public void DonMove()
    {
        InputMgr.Instance.StartOrCloseInputMgr(false);
    }
    /// <summary>
    /// 用于TimeLine调用的恢复移动方法
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
