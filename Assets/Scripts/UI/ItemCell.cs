using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemCell : BasePanel
{
    private obj obj1 = null;
    public void Start()
    {
       EventTrigger e =  GetControl<Image>("objIcon").AddComponent<EventTrigger>();
       EventTrigger.Entry entry = new EventTrigger.Entry();
       entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener((data) =>
        {
            UIMgr.Instance.ShowPanel<TipsPanel>(E_UILayer.System, (panel) =>
            {
                panel.InitInfo(obj1);
                panel.transform.position = this.GetControl<Image>("objIcon").transform.position;


            });
        });
        e.triggers.Add(entry);
        EventTrigger.Entry exit = new EventTrigger.Entry();
        exit.eventID = EventTriggerType.PointerExit;
        exit.callback.AddListener((data) =>
        {
            UIMgr.Instance.HidePanel<TipsPanel>();
          
        });
        e.triggers.Add(exit);

    }
    public override void HideMe()
    {
        //throw new System.NotImplementedException();
    }

    public override void ShowMe()
    {
       
    }
    public void InitInfo(obj obj)
    {
        this.obj1 = obj;
        //ABResMgr.Instance.LoadResAsync<Sprite>("icon", obj.icon, (icon) =>
        //{

        //    GetControl<Image>("objIcon").sprite = icon as Sprite;
        //});
        GetControl<Image>("objIcon").sprite = ResMgr.Instance.Load<Sprite>("icon/" + obj.icon);
        GetControl<Text>("num").text = obj.nowNum.ToString();

    }

}
