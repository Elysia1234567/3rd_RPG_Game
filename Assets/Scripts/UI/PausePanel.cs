using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : BasePanel
{
   

    public override void HideMe()
    {
        InputMgr.Instance.StartOrCloseInputMgr(true);

    }

    public override void ShowMe()
    {
        InputMgr.Instance.StartOrCloseInputMgr(false);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void ClickBtn(string btnName)
    {
        switch (btnName)
        {
            case "HelpBtn":
                UIMgr.Instance.ShowPanel<HelpPanel>(E_UILayer.System);

                break;
            case "SettingBtn":
                UIMgr.Instance.ShowPanel<SettingPanel>(E_UILayer.System);

                break;
            case "ExitBtn ":
                Debug.Log("1");
                UIMgr.Instance.HidePanel<PausePanel>();
                break;
        }
    }
}
