using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    LocalizeStringEvent localizeStringEvent;
    [SerializeField] private LocalizedString localStringScore;
    [SerializeField] private Text textComp; // ������ʾ������ TextMeshPro ���
    void OnEnable()
    {
        localizeStringEvent = GetComponent<LocalizeStringEvent>();
        localizeStringEvent.StringReference.SetReference("UI", "Test");
        //localStringScore.Arguments = new object[] { "��ã��ҽа���ϣ�", "Hello,my name is Elysia", "����ˤ��ϣ�˽�Ϥ������Ǥ�" };
        //localStringScore.RefreshString();
        //localStringScore.StringChanged += UpdateText;
        //var lodingResult = LocalizationSettings.StringDatabase.GetTableEntry("UI", "BeginGame");
        //textComp.text= lodingResult.Entry.GetLocalizedString();
    }

    private void UpdateText(string value)
    {
        textComp.text = value; // ���� TextMeshPro ������ı�
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
