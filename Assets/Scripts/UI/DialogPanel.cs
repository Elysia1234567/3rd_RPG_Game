using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Playables;

public class DialogPanel : BasePanel
{
    public LocalizeStringEvent nameLocalizeStringEvent;//挂在文本上的本地化事件
    public LocalizeStringEvent localizeStringEvent;//挂在文本上的本地化事件
    public DialogInfoContainer container;//装表的容器
    public Dictionary<int, DialogInfo> dialogs;//一个表的字典
    public List<DialogInfo> dialogInfos;//装载一个章节的对话信息
    public int index;//用于指向对话内容的标志
    public string content;//对话
    public List<DialogInfo> selectInfos;//装载选项的内容信息
    public bool isNext=true;//当选择选项的时候应该改成false，这样点击屏幕不会跳对话
    public PlayableDirector director;
    private Animator anima;

    public override void HideMe()
    {
        StopAllCoroutines();
       

    }

    public override void ShowMe()
    {
        anima= GetComponent<Animator>();
        director=GameObject.Find("TimeLineMgr").GetComponent<PlayableDirector>();
        InputMgr.Instance.StartOrCloseInputMgr(false);

    }

    public void Init(int id)
    {
        dialogInfos = new List<DialogInfo>();
        selectInfos = new List<DialogInfo>();
        container = BinaryDataMgr.Instance.GetTable<DialogInfoContainer>();
        //Debug.Log(container);
        dialogs = container.dataDic;
        localizeStringEvent = GetControl<Text>("dialog").gameObject.GetComponent<LocalizeStringEvent>();
        nameLocalizeStringEvent = GetControl<Text>("name").gameObject.GetComponent<LocalizeStringEvent>();
        foreach (var item in dialogs)
        {
            if(item.Value.charpterId == id)
            {
                dialogInfos.Add(item.Value);
            }
        }
        GetControl<Text>("name").text = LocalizationSettings.StringDatabase.GetTable("Name").GetEntry(dialogInfos[0].name.ToString()).GetLocalizedString();
        if (dialogInfos[0].isVible)
        {
            EventCenter.Instance.EventTrigger(E_EventType.E_Camera_Shake);
        }
        if (dialogInfos[0].spriteName!="")
        {
            transform.Find("BK").Find("person").gameObject.SetActive(true);
            ABMgr.Instance.LoadResAsync<Sprite>("character", dialogInfos[0].spriteName, (obj) =>
            {
                GetControl<Image>("person").sprite = obj;
            });
        }
        else
        {
            transform.Find("BK").Find("person").gameObject.SetActive(false);
        }
        localizeStringEvent.StringReference.SetReference("Dialog", dialogInfos[0].id);
        string lodingResult= LocalizationSettings.StringDatabase.GetTable("Dialog").GetEntry(dialogInfos[0].id.ToString()).GetLocalizedString();
        
        content = lodingResult;
        if (dialogInfos[0].musicName!="")
            MusicMgr.Instance.PlayBKMusic(dialogInfos[0].musicName);
        if (dialogInfos[0].soundName != "")
            MusicMgr.Instance.PlaySound(dialogInfos[0].soundName);
        StartCoroutine(SetTextUI(content));
        index = dialogInfos[0].nextId-1;
        //GetControl<Text>("dialog").text=
    }

    public void Update()
    {
        if(Input.GetMouseButtonDown(0)&&isNext)
        {
            //Debug.Log(dialogInfos[index].type);
            UpdateText();
           
        }
    }

    public void UpdateText()
    {
        MusicMgr.Instance.PlayOrPauseSound(false);
        if (index == -1)
        {
            if(DialogMgr.Instance.isTimeLine)
            {
                director.Play();
                DialogMgr.Instance.isTimeLine = false;
            }
            else
            {
                InputMgr.Instance.StartOrCloseInputMgr(true);
            }
            StartCoroutine(ShowDisExitAnima());
            
        }
        else
        {

            while (dialogInfos[index].type == 2)
            {
                selectInfos.Add(dialogInfos[index]);
                index++;
            }
            if (selectInfos.Count > 0)
            {
                UIMgr.Instance.ShowPanel<SelectPanel>(E_UILayer.System, (obj) =>
                {
                    obj.Init(selectInfos);
                    isNext = false;
                });
            }
            else
            {
                if (dialogInfos[index].isVible)
                {
                    EventCenter.Instance.EventTrigger(E_EventType.E_Camera_Shake);
                }
                //StopCoroutine(SetTextUI(content));
                StopAllCoroutines();
                //Debug.Log(dialogInfos[index].musicName);
                if (dialogInfos[index].musicName != "")
                    MusicMgr.Instance.PlayBKMusic(dialogInfos[index].musicName);
                if (dialogInfos[index].soundName != "")
                    MusicMgr.Instance.PlaySound(dialogInfos[index].soundName);
                GetControl<Text>("name").text = LocalizationSettings.StringDatabase.GetTable("Name").GetEntry(dialogInfos[index].name.ToString()).GetLocalizedString();
                if (dialogInfos[index].spriteName != "")
                {
                    transform.Find("BK").Find("person").gameObject.SetActive(true);
                    ABMgr.Instance.LoadResAsync<Sprite>("character", dialogInfos[index].spriteName, (obj) =>
                    {
                        GetControl<Image>("person").sprite = obj;
                    });
                }
                else
                {
                    transform.Find("BK").Find("person").gameObject.SetActive(false);
                }
                localizeStringEvent.StringReference.SetReference("Dialog", dialogInfos[index].id);
                string lodingResult = LocalizationSettings.StringDatabase.GetTable("Dialog").GetEntry(dialogInfos[index].id.ToString()).GetLocalizedString();

                string temp = lodingResult;
                StartCoroutine(SetTextUI(temp));
                index = dialogInfos[index].nextId - 1;
            }

        }
    }

    IEnumerator SetTextUI(string target)
    {
        string testString = target;
        GetControl<Text>("dialog").text = "";
        for (int i = 0; i < testString.Length; i++)
        {
            GetControl<Text>("dialog").text += testString[i];
            yield return new WaitForSeconds(0.05f);
        }
        MusicMgr.Instance.PlayOrPauseSound(false);
    }

    IEnumerator ShowDisExitAnima()
    {
        anima.Play("DialogDisappearAnimation");
        yield return new WaitForSeconds(0.3f);
        UIMgr.Instance.HidePanel<DialogPanel>(true);
    }
}
