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
    /// �����½ڵ�id���ö�Ӧ�ĶԻ���Ŀǰ����֪��������Щ���ܣ������ִ��¼����Ⱥ����й��Ե�ʱ�����Ż�
    /// </summary>
    /// <param name="id">�¼�id</param>
    /// <param name="action">��ʾ�Ի�ʱ�ᴥ�����¼�</param>
   public void ShowDialog(int id,UnityAction action=null)
   {
        UIMgr.Instance.ShowPanel<DialogPanel>(E_UILayer.System,(obj)=>
        {
           
            obj.Init(id);
        });
    }

}



