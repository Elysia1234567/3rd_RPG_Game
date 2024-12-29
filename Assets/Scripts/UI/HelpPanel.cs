using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpPanel : BasePanel
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
            case "ExitBtn":
                UIMgr.Instance.HidePanel<HelpPanel>();
                break;
      
        }
    }
}
