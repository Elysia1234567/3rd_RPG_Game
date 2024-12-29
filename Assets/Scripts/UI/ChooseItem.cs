using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class ChooseItem : BasePanel
{
    public LocalizeStringEvent localizeStringEvent;//挂在文本上的本地化事件
    public override void HideMe()
    {
        
    }

    public override void ShowMe()
    {
        
    }

    public void Init(int index,int nextId)
    {
        //Debug.Log(index + " " + nextId);
        //Debug.Log("进入");
        localizeStringEvent = GetControl<Text>("chooseText").gameObject.GetComponent<LocalizeStringEvent>();
       
        localizeStringEvent.StringReference.SetReference("Dialog",index);
        string lodingResult = LocalizationSettings.StringDatabase.GetTable("Dialog").GetEntry(index.ToString()).GetLocalizedString();
        GetControl<Text>("chooseText").text = lodingResult;
        transform.GetComponent<Button>().onClick.AddListener(()=>
        {
            UIMgr.Instance.GetPanel<DialogPanel>((obj) =>
            {
                obj.isNext = true;
                obj.index=nextId-1;
                obj.selectInfos.Clear();
                obj.UpdateText();
                UIMgr.Instance.HidePanel<SelectPanel>(true);
            });
        });
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
