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
    private LocalizeStringEvent localizeStringEvent;//�����ı��ϵı��ػ��¼�

    public override void HideMe()
    {
        
    }

    public override void ShowMe()
    {
        
    }
    /// <summary>
    /// ��������ʧ�͵���
    /// </summary>
    /// <param name="id">���ػ�table��ļ�</param>
    /// <param name="args">����ı����ж�̬�޸ĵĲ�������Դ�����</param>
    public void Init(int id, string[] args=null)
    {
        localizeStringEvent = GetControl<Text>("tip").gameObject.GetComponent<LocalizeStringEvent>();
        localizeStringEvent.StringReference.SetReference("WarnTable", id);
        object[] objNumbers = args.Cast<object>().ToArray();
        GetControl<Text>("tip").text =string.Format( LocalizationSettings.StringDatabase.GetTable("WarnTable").GetEntry(id.ToString()).GetLocalizedString(),objNumbers);

        StartCoroutine(ShowWarn());
    }

    public void InitStatic(int id, string buttonName = "ȷ��",UnityAction action = null,string[] args = null)
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
