using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogMgr : BaseManager<DialogMgr>
{
    public bool isTimeLine;
    private DialogMgr()
    {

    }
    /// <summary>
    /// 根据章节的id调用对应的对话，目前还不知道会有哪些功能，所以现传事件，等后面有共性的时候再优化
    /// </summary>
    /// <param name="id">事件id</param>
    /// <param name="action">显示对话时会触发的事件</param>
   public void ShowDialog(int id,UnityAction action=null)
   {
        UIMgr.Instance.ShowPanel<DialogPanel>(E_UILayer.System,(obj)=>
        {
           
            obj.Init(id);
        });
    }

}



