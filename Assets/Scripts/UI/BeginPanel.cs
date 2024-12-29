using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Threading;

public class BeginPanel : BasePanel
{
    //public float fadeTime = 1.0f;
    public override void HideMe()
    {
        InputMgr.Instance.StartOrCloseInputMgr(true);

    }

    public override void ShowMe()
    {
        //Debug.Log(GetControl<TextMeshProUGUI>("test").text);
        //GetControl<Image>("ChangeIcon").DOFade(0, fadeTime);
        InputMgr.Instance.StartOrCloseInputMgr(false);


    }
    public void Update()
    {

        //switch(GameMgr.Instance.LanguageType)
        //{
        //    case LanguageType.English:
                
        //        break;
        //    case LanguageType.Chinese:
        //        break;
        //}
    }
    protected override void ClickBtn(string btnName)
    {
        switch (btnName)
        {
            case "BeginBtn":

                //int a = 0;
                //ThreadPool.QueueUserWorkItem(new WaitCallback(changeScene), a);//将方法添加进线程池，并传入参数
                StartCoroutine("enumerator");
    

                break;
            case "SettingBtn":
                //UIMgr.Instance.HidePanel<BeginPanel>();
                UIMgr.Instance.ShowPanel<SettingPanel>(E_UILayer.System);
                break;
            case "ExitBtn":
                Debug.Log("退出游戏了了了");
                Application.Quit();
                break;
        }
    }
    IEnumerator enumerator()
    {
        UIMgr.Instance.GetPanel<ChangePanel>((cp) =>
        {
            cp.HideMe();
        });
        yield return new WaitForSeconds(1f);
        SceneMgr.Instance.LoadScene("GameScene", () =>
        {

            UIMgr.Instance.ShowPanel<GamePanel>(E_UILayer.System);
            UIMgr.Instance.GetPanel<ChangePanel>((cp) =>
            {
                cp.ShowMe();
            });
            UIMgr.Instance.HidePanel<BeginPanel>();


        });
    }

}
