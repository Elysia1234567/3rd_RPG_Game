using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TipsPanel : BasePanel
{
    public override void HideMe()
    {
        //throw new System.NotImplementedException();
    }

    public override void ShowMe()
    {
        //throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InitInfo(obj obj)
    {
       
        //ABResMgr.Instance.LoadResAsync<Sprite>("icon", obj.icon, (icon) =>
        //{

        //    GetControl<Image>("objIcon").sprite = icon as Sprite;
        //});
        GetControl<Image>("ObjIcon").sprite = ResMgr.Instance.Load<Sprite>("icon/" + obj.icon);
        GetControl<Text>("num").text = "ÊýÁ¿£º "+obj.nowNum.ToString();
        GetControl<Text>("name").text = obj.name.ToString();
        GetControl<Text>("tips").text = obj.tips.ToString();

    }
}
