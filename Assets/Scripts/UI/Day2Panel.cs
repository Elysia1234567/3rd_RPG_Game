using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Components;

public class Day2Panel : BasePanel
{
    int FllowChange;
    public LocalizeStringEvent DiaryLocalizeStringEvent;//�����ı��ϵı��ػ��¼�

    public override void HideMe()
    {
        InputMgr.Instance.StartOrCloseInputMgr(true);

        FllowChange = 0;

    }

    public override void ShowMe()
    {
        InputMgr.Instance.StartOrCloseInputMgr(false);
        FllowChange = 0;
        DiaryLocalizeStringEvent.StringReference.SetReference("DiaryTable", 2);
        StartCoroutine(SetTextUI(LocalizationSettings.StringDatabase.GetTable("DiaryTable").GetEntry("2").GetLocalizedString()));

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




            case "SelectBtn11":
                GetControl<Image>("Select12p").transform.DOScale(0f, 0.3f);


                GetControl<Image>("Select12p").gameObject.SetActive(false);

                GetControl<Image>("Select11p").gameObject.SetActive(true);

                GetControl<Image>("Select11p").transform.DOScale(1f, 0.3f);

                break;
            case "SelectBtn12":
                GetControl<Image>("Select11p").transform.DOScale(0f, 0.3f);


                GetControl<Image>("Select11p").gameObject.SetActive(false);


                GetControl<Image>("Select12p").gameObject.SetActive(true);

                GetControl<Image>("Select12p").transform.DOScale(1f, 0.3f);



                break;
            case "SelectBtn21":
                GetControl<Image>("Select22p").transform.DOScale(0f, 0.3f);


                GetControl<Image>("Select22p").gameObject.SetActive(false);

                GetControl<Image>("Select21p").gameObject.SetActive(true);

                GetControl<Image>("Select21p").transform.DOScale(1f, 0.3f);




                break;
            case "SelectBtn22":
                GetControl<Image>("Select21p").transform.DOScale(0f, 0.3f);


                GetControl<Image>("Select21p").gameObject.SetActive(false);

                GetControl<Image>("Select22p").gameObject.SetActive(true);

                GetControl<Image>("Select22p").transform.DOScale(1f, 0.3f);


                break;
            case "returnBtn":





                UIMgr.Instance.HidePanel<Day2Panel>(true);

                break;
            case "confirmBtn1":
                
                if (GetControl<Image>("Select11p").gameObject.activeInHierarchy)
                {
                    FllowChange -= 10;
                }
                if (GetControl<Image>("Select12p").gameObject.activeInHierarchy)
                {
                    FllowChange += 10;
                }
                GetControl<Text>("num").text = FllowChange.ToString();

                GetControl<Button>("SelectBtn11").gameObject.SetActive(false);
                GetControl<Button>("SelectBtn12").gameObject.SetActive(false);

                GetControl<Image>("result").gameObject.SetActive(true);

                GetControl<Image>("result").transform.DOScale(1f, 0.3f);

                GetControl<Button>("returnBtn").gameObject.SetActive(true);
                GetControl<Button>("confirmBtn1").gameObject.SetActive(false);


                break;
            case "confirmBtn2":
                if (GetControl<Image>("Select21p").gameObject.activeInHierarchy)
                {
                    FllowChange += 10;
                }
                if (GetControl<Image>("Select22p").gameObject.activeInHierarchy)
                {
                    FllowChange -= 10;
                }
                GetControl<Text>("num").text = FllowChange.ToString();
                if (FllowChange < 0)
                {

                }
                GetControl<Image>("result").gameObject.SetActive(true);

                GetControl<Image>("result").transform.DOScale(1f, 0.3f);

                GetControl<Button>("returnBtn").gameObject.SetActive(true);
                GetControl<Button>("confirmBtn2").gameObject.SetActive(false);

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