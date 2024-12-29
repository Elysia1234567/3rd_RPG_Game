using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : BaseManager<GameMgr>
{
    private GameMgr()
    {

    }
    //是否开启震动效果
    public bool isVib = true;
    //震动效果
    public float VibValue = 1.0f;
    //语音类型
    public LanguageType LanguageType = LanguageType.Chinese;
}
