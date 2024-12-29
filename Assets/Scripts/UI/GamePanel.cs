using DG.Tweening;
using MoreMountains.Feedbacks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.Localization.Plugins.XLIFF.V20;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Splines;
using UnityEngine.UI;

public class GamePanel : BasePanel
{
    //public float fadeTime = 1.0f;

    //public  string testString ;
    ////测试用，用于改变localization本地化的字符串
    //[SerializeField] private LocalizedString localStringScore;

    public MMFeedbacks ClickFeedback;
    private bool flag = true;
    public override void HideMe()
    {
        //GameObject vC = GameObject.Find("Virtual Camera");
        //GameObject mC = GameObject.Find("Main Camera");
        //GameObject l2D = GameObject.Find("Lighting Manager 2D");
    }

    public override void ShowMe()
    {
        //localStringScore.Arguments = new object[] { "你好，我叫爱莉希娅", "Hello,my name is Elysia", "こんにちは，私はあいぃです" };
        //GetControl<Image>("ChangeIcon").DOFade(0, fadeTime);
        

    }

    // Start is called before the first frame update
    void Start()
    {
        //GameObject vC = GameObject.Find("Virtual Camera");
        //GameObject mC = GameObject.Find("Main Camera");
        //GameObject l2D = GameObject.Find("Lighting Manager 2D");
        //StartCoroutine(SetTextUI());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void ClickBtn(string btnName)
    {
        switch (btnName)
        {
            case "PauseBtn":
                ClickFeedback.PlayFeedbacks();
                UIMgr.Instance.ShowPanel<PausePanel>(E_UILayer.System);

                break;
            case "test1":
                EventCenter.Instance.EventTrigger(E_EventType.E_Camera_Shake);
                break;
            case "test2":
                MusicMgr.Instance.PlaySound("hit_4");
                break;
            case "test3":
                UIMgr.Instance.ShowPanel<LanguagePanel>(E_UILayer.System);

                break;
            case "dialogTest":
                DialogMgr.Instance.ShowDialog(1);
                break;
            case "runTest":
                UIMgr.Instance.ShowPanel<RunChoosePanel>(E_UILayer.System);   
                break;
            case "BagTest":
                UIMgr.Instance.ShowPanel<BagPanel>(E_UILayer.System);

                break;
            case "ChangeScene":
          
            
                StartCoroutine("enumerator");


                break;
            case "minigameTestBtn":
                UIMgr.Instance.ShowPanel<DetectivePanel>(E_UILayer.System);

                break;
            case "DiaryTest":
                if (PlayerMgr.Instance.nowDays == 1)
                {
                    UIMgr.Instance.ShowPanel<Day1Panel>(E_UILayer.System);
                    PlayerMgr.Instance.nowDays++;
                    break;
                }
                if (PlayerMgr.Instance.nowDays == 2)
                {
                    UIMgr.Instance.ShowPanel<Day2Panel>(E_UILayer.System);
                    PlayerMgr.Instance.nowDays++;
                    break;

                }
                if (PlayerMgr.Instance.nowDays == 3)
                {
                    UIMgr.Instance.ShowPanel<Day3Panel>(E_UILayer.System);
                    PlayerMgr.Instance.nowDays++;
                    break;

                }
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
            GameObject player = GameObject.Find("Player1");
            player.transform.position = new Vector3(17, -1.2f, 0);
            yield return new WaitForSeconds(0.1f);

            SceneMgr.Instance.LoadScene("SampleScene", () =>
            {


                UIMgr.Instance.GetPanel<ChangePanel>((cp) =>
                {
                    cp.ShowMe();
                    UIMgr.Instance.ShowPanel<DetectivePanel>(E_UILayer.System);
                    UIMgr.Instance.HidePanel<GamePanel>();
                    EventCenter.Instance.EventTrigger<bool>(E_EventType.E_Cg, true);
                  
              

                });



            });
        

      
    }

    ///// <summary>
    ///// 测试字符逐个出现的函数
    ///// </summary>
    ///// <returns></returns>
    //IEnumerator SetTextUI()
    //{
    //    testString = GetControl<Text>("Test").text;
    //    GetControl<Text>("Test").text = "";
    //    for (int i = 0;i<testString.Length;i++)
    //    {
    //        GetControl<Text>("Test").text += testString[i];
    //        yield return new WaitForSeconds(0.2f);
    //    }
    //}
}
