using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    int speed = 10;
    public GameObject RotaGameObj;
    private void Up()
    {
        RotaGameObj.transform.Translate(speed * transform.up * Time.deltaTime);

        //Vector2 position = transform.position;
        //Debug.Log(Time.deltaTime*speed);

        ////RotaGameObj.transform.position.y = position.y + Time.deltaTime*speed;
        ////Debug.Log(position);
        ////Debug.Log(position);

        ////transform.position = position;
        //Debug.Log(transform.position);

        //Debug.Log(position);
    }
    private void Down()
    {
        RotaGameObj.transform.Translate(-speed * transform.up * Time.deltaTime);

        //Vector2 position = transform.position;
        //position.y = position.y - speed * Time.deltaTime;
        //transform.position = position;

    }
    private void Left()
    {
        RotaGameObj.transform.Translate(-speed * transform.right * Time.deltaTime);
        //Vector2 position = transform.position;
        //position.x = position.x - speed * Time.deltaTime;
        //transform.position = position;

    }
    private void Right()
    {
        RotaGameObj.transform.Translate(speed * transform.right * Time.deltaTime);
        //Vector2 position = transform.position;
        //position.x = position.x + speed * Time.deltaTime;
        //transform.position = position;

    }
    void Start()
    {

        //DontDestroyOnLoad(gameObject);

        InputMgr.Instance.StartOrCloseInputMgr(true);
        //修改，初始化键位，事件类型，触发该事件的按钮，触发时机（按下，抬起，长按）
        InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_Input_Up, KeyCode.W, InputInfo.E_InputType.Always);
        InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_Input_Down, KeyCode.S, InputInfo.E_InputType.Always);
        InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_Input_Left, KeyCode.A, InputInfo.E_InputType.Always);
        InputMgr.Instance.ChangeKeyboardInfo(E_EventType.E_Input_Right, KeyCode.D, InputInfo.E_InputType.Always);
        UnityAction up = new UnityAction(Up);
        UnityAction down = new UnityAction(Down);
        UnityAction left = new UnityAction(Left);
        UnityAction right = new UnityAction(Right);

        EventCenter.Instance.AddEventListener(E_EventType.E_Input_Up,up);
        EventCenter.Instance.AddEventListener(E_EventType.E_Input_Down, down);
        EventCenter.Instance.AddEventListener(E_EventType.E_Input_Left, left);
        EventCenter.Instance.AddEventListener(E_EventType.E_Input_Right, right);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
