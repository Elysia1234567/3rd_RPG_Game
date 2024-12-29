using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SettingPanel : BasePanel
{
    public RectTransform panel;

    public override void HideMe()
    {
        InputMgr.Instance.StartOrCloseInputMgr(true);

    }

    public override void ShowMe()
    {
        InputMgr.Instance.StartOrCloseInputMgr(false);

    }

    protected override void ClickBtn(string btnName)
    {
       switch (btnName)
        {
            case "ExitBtn":
                StartCoroutine("enumerator");

                break;
        }
    }
    protected override void ToggleValueChange(string sliderName, bool value)
    {
        switch (sliderName)
        {
            case "BKMusic":
                if (value)
                {
                    MusicMgr.Instance.PlayBKMusic("Begin");

                }
                else
                {
                    MusicMgr.Instance.StopBKMusic();

                }
                break;
            case "Sound":
                if (value)
                {
                    MusicMgr.Instance.isSound=true;

                }
                else
                {
                    MusicMgr.Instance.isSound=false;

                }
                break;
            case "Vib":
                if (value)
                {
                    GameMgr.Instance.isVib = true;

                }
                else
                {
                    GameMgr.Instance.isVib = false;

                }

                break;
        }
    }
    protected override void SliderValueChange(string sliderName, float value)
    {
        switch(sliderName)
        {
            case "BKValue":
                MusicMgr.Instance.ChangeBKMusicValue(value);
                break;
            case "SoundValue":
                MusicMgr.Instance.ChangeSoundValue(value);
                break;
            case "VibValue":
                GameMgr.Instance.VibValue=value;
                Debug.Log(GameMgr.Instance.VibValue);

                break;
        }
    }
    IEnumerator enumerator()
    {
        panel.DOAnchorPos(new Vector2(0, -800), 0.6f, false).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.5f);
        UIMgr.Instance.HidePanel<SettingPanel>();




    }
}
