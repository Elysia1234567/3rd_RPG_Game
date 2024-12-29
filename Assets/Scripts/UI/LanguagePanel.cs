using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LanguagePanel : BasePanel
{
    public override void HideMe()
    {
        InputMgr.Instance.StartOrCloseInputMgr(true);

    }

    public override void ShowMe()
    {
        InputMgr.Instance.StartOrCloseInputMgr(false);

    }
    //0中文1英文2日语
    protected override void ClickBtn(string btnName)
    {
        switch (btnName)
        {
            case "Chinese":
                // 切换到指定索引的语言
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];


                break;
            case "English":
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];

                break;
            case "Japanese":
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[2];

                break;
            case "ExitBtn":
                UIMgr.Instance.HidePanel<LanguagePanel>();
                break;

        }
    }

}
