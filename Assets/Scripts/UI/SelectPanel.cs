using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SelectPanel : BasePanel
{
    public override void HideMe()
    {
       
    }

    public override void ShowMe()
    {
        
    }

    public void Init(List<DialogInfo> selectInfos)
    {
        for(int i=0;i<selectInfos.Count; i++)
        {
            int index = i;
            //Debug.Log(selectInfos[i].id+" " + selectInfos[i].nextId);
            ResMgr.Instance.LoadAsync<GameObject>("UI/ChooseItem",(obj)=>
            {
                GameObject selection=GameObject.Instantiate(obj, transform.Find("BK").Find("grid"),false);
               
                selection.GetComponent<RectTransform>().localScale = Vector3.one;
                selection.GetComponent<ChooseItem>().Init(selectInfos[index].id, selectInfos[index].nextId);
            });
           
        }
    }
}
