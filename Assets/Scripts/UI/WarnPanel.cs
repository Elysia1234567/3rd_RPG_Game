using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class WarnPanel : BasePanel
{
    private LocalizeStringEvent localizeStringEvent;//挂在文本上的本地化事件

    public override void HideMe()
    {
        
    }

    public override void ShowMe()
    {
        
    }
    /// <summary>
    /// 唤出会消失型弹窗
    /// </summary>
    /// <param name="id">本地化table里的键</param>
    /// <param name="args">如果文本里有动态修改的参数则可以传进来</param>
    public void Init(int id, string[] args=null)
    {
        localizeStringEvent = GetControl<Text>("tip").gameObject.GetComponent<LocalizeStringEvent>();
        localizeStringEvent.StringReference.SetReference("WarnTable", id);
        object[] objNumbers = args.Cast<object>().ToArray();
        GetControl<Text>("tip").text =string.Format( LocalizationSettings.StringDatabase.GetTable("WarnTable").GetEntry(id.ToString()).GetLocalizedString(),objNumbers);

        StartCoroutine(ShowWarn());
    }

    public void InitStatic(int id, string buttonName = "确定",UnityAction action = null,string[] args = null)
    {
        StartCoroutine(ShowWarnStatic());
        InputMgr.Instance.StartOrCloseInputMgr(false);
        localizeStringEvent = GetControl<Text>("tipStatic").gameObject.GetComponent<LocalizeStringEvent>();
        localizeStringEvent.StringReference.SetReference("WarnTable", id);
        if(args != null)
        {
            object[] objNumbers = args.Cast<object>().ToArray();
            GetControl<Text>("tipStatic").text = string.Format(LocalizationSettings.StringDatabase.GetTable("WarnTable").GetEntry(id.ToString()).GetLocalizedString(), objNumbers);
        }
        else
        {
            GetControl<Text>("tipStatic").text = LocalizationSettings.StringDatabase.GetTable("WarnTable").GetEntry(id.ToString()).GetLocalizedString();
        }
        GetControl<Text>("check").text=buttonName;
        GetControl<Button>("button").onClick.AddListener(() =>
        {
            action();
            
        });
    }

    IEnumerator ShowWarn()
    {
        GetControl<Image>("BK").transform.DOScale(1f, 0.3f);
        yield return new WaitForSeconds(2.3f);
        GetControl<Image>("BK").transform.DOScale(0f, 0.3f);
        yield return new WaitForSeconds(0.3f);
        //UIMgr.Instance.HidePanel<WarnPanel>(true);

    }

    IEnumerator ShowWarnStatic()
    {
        GetControl<Image>("BKStatic").transform.DOScale(1, 0.3f);
        yield return new WaitForSeconds(0.3f);
        
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
