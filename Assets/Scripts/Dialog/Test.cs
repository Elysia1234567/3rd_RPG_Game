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
    [SerializeField] private Text textComp; // 用于显示分数的 TextMeshPro 组件
    void OnEnable()
    {
        localizeStringEvent = GetComponent<LocalizeStringEvent>();
        localizeStringEvent.StringReference.SetReference("UI", "Test");
        //localStringScore.Arguments = new object[] { "你好，我叫爱莉希娅", "Hello,my name is Elysia", "こんにちは，私はあいぃです" };
        //localStringScore.RefreshString();
        //localStringScore.StringChanged += UpdateText;
        //var lodingResult = LocalizationSettings.StringDatabase.GetTableEntry("UI", "BeginGame");
        //textComp.text= lodingResult.Entry.GetLocalizedString();
    }

    private void UpdateText(string value)
    {
        textComp.text = value; // 更新 TextMeshPro 组件的文本
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
