using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEditor;
using System;
using System.Threading;

public class ChangePanel : BasePanel
{

    //public float fadeTime = 1.0f;
    public int timeId = -1;
    public override void HideMe()
    {

        //throw new System.NotImplementedException();
        GetControl<Image>("ChangeIcon").DOFade(1, 1.0f);
        


    }

    public override void ShowMe()
    {
        //throw new System.NotImplementedException();
        GetControl<Image>("ChangeIcon").DOFade(0, 1.0f);


    }
    public void ChangeScene(float times = 1.0f)
    {
        ThreadPool.QueueUserWorkItem(new WaitCallback(change), times);//将方法添加进线程池，并传入参数

    }
    private void change(object times)//废弃
    {
        InputMgr.Instance.StartOrCloseInputMgr(false);


        GetControl<Image>("ChangeIcon").DOFade(1, 1.0f);
        Thread.Sleep((int)(1.0f * 1000));
        GetControl<Image>("ChangeIcon").DOFade(0, 1.0f);
        InputMgr.Instance.StartOrCloseInputMgr(true);

    }
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
