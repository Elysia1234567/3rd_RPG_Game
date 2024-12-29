using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class DiaryPanel : BasePanel
{
    public LocalizeStringEvent DiaryLocalizeStringEvent;//挂在文本上的本地化事件
    public LocalizeStringEvent Select1localizeStringEvent;//挂在文本上的本地化事件
    public LocalizeStringEvent Select2localizeStringEvent;//挂在文本上的本地化事件
    public string content;
    int maxTurn;
    int nowTurn;
    int FllowChange;
    int nowid;
    string nowTableId;
    public override void HideMe()
    {
        StopAllCoroutines();

        InputMgr.Instance.StartOrCloseInputMgr(true);

    }

    public override void ShowMe()
    {
        InputMgr.Instance.StartOrCloseInputMgr(false);

        Init(PlayerMgr.Instance.nowDays);
        PlayerMgr.Instance.nowDays++;
    }
    public void Init(int id)
    {
        FllowChange = 0;
        nowid = id;
        nowTableId = id.ToString("D3");
        maxTurn = BinaryDataMgr.Instance.GetTable<DiaryInfoContainer>().dataDic[id].SelectTimes;
        nowTurn = 1;
        DiaryLocalizeStringEvent.StringReference.SetReference("DiaryTable", id);
        string lodingResult = LocalizationSettings.StringDatabase.GetTable("DiaryTable").GetEntry(id.ToString()).GetLocalizedString();
        content = lodingResult;
        GetControl<Text>("Text1").text = LocalizationSettings.StringDatabase.GetTable("SelectTable").GetEntry(id.ToString("D3") + nowTurn.ToString() + "1").GetLocalizedString();
        GetControl<Text>("Text2").text = LocalizationSettings.StringDatabase.GetTable("SelectTable").GetEntry(id.ToString("D3") + nowTurn.ToString() + "2").GetLocalizedString();

        StartCoroutine(SetTextUI(content));
    }
    public void next ()
    {
        GetControl<Text>("DiaryText").text = LocalizationSettings.StringDatabase.GetTable("DiaryTable").GetEntry(nowTableId).GetLocalizedString();
        Debug.Log(nowid.ToString("D3") + nowTurn.ToString());
        GetControl<Text>("Text1").text = LocalizationSettings.StringDatabase.GetTable("SelectTable").GetEntry(nowid.ToString("D3") + nowTurn.ToString() + "1").GetLocalizedString();
        GetControl<Text>("Text2").text = LocalizationSettings.StringDatabase.GetTable("SelectTable").GetEntry(nowid.ToString("D3") + nowTurn.ToString() + "2").GetLocalizedString();
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
            case "SelectBtn1":
                nowTableId += "1";
          
                if(nowTurn == 1)
                {
                 
                    FllowChange += BinaryDataMgr.Instance.GetTable<DiaryInfoContainer>().dataDic[nowid].Select11;
                    if (nowTurn == maxTurn)
                    {
                        Debug.Log(FllowChange);
                        UIMgr.Instance.HidePanel<DiaryPanel>();

                        break;
                    }

                    nowTurn++;
                    next();
                    break;
                }
                if (nowTurn == 2)
                {
                 
                    FllowChange += BinaryDataMgr.Instance.GetTable<DiaryInfoContainer>().dataDic[nowid].Select21;
                    if (nowTurn == maxTurn)
                    {
                        Debug.Log(FllowChange);
                        UIMgr.Instance.HidePanel<DiaryPanel>();

                        break;
                    }

                    nowTurn++;
                    next();
                    break;
                }
                if (nowTurn == 3)
                {

                    FllowChange += BinaryDataMgr.Instance.GetTable<DiaryInfoContainer>().dataDic[nowid].Select31;
                    if (nowTurn == maxTurn)
                    {
                        Debug.Log(FllowChange);
                        UIMgr.Instance.HidePanel<DiaryPanel>();

                        break;
                    }

                    nowTurn++;
                    next();
                    break;
                }

                break;
            case "SelectBtn2":
                nowTableId += "2";
      

                if (nowTurn == 1)
                {
                 
                    FllowChange += BinaryDataMgr.Instance.GetTable<DiaryInfoContainer>().dataDic[nowid].Select12;
                    if (nowTurn == maxTurn)
                    {
                        Debug.Log(FllowChange);
                        UIMgr.Instance.HidePanel<DiaryPanel>();

                        break;
                    }

                    nowTurn++;
                    next();
                    break;
                }
                if (nowTurn == 2)
                {
                
                    FllowChange += BinaryDataMgr.Instance.GetTable<DiaryInfoContainer>().dataDic[nowid].Select22;
                    if (nowTurn == maxTurn)
                    {
                        Debug.Log(FllowChange);
                        UIMgr.Instance.HidePanel<DiaryPanel>();

                        break;
                    }

                    nowTurn++;
                    next();
                    break;
                }
                if (nowTurn == 3)
                {

                    FllowChange += BinaryDataMgr.Instance.GetTable<DiaryInfoContainer>().dataDic[nowid].Select32;
                    if (nowTurn == maxTurn)
                    {
                        Debug.Log(FllowChange);
                        UIMgr.Instance.HidePanel<DiaryPanel>();

                        break;
                    }

                    nowTurn++;
                    next();
                    break;
                }
                break;
        }
    }
    IEnumerator SetTextUI(string target)
    {
        string testString = target;
        GetControl<Text>("DiaryText").text = "";
        for (int i = 0; i < testString.Length; i++)
        {
            GetControl<Text>("DiaryText").text += testString[i];
            yield return new WaitForSeconds(0.05f);
        }
        MusicMgr.Instance.PlayOrPauseSound(false);
    }
}
