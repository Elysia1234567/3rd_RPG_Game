using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : BaseManager<GameMgr>
{
    private GameMgr()
    {

    }
    //�Ƿ�����Ч��
    public bool isVib = true;
    //��Ч��
    public float VibValue = 1.0f;
    //��������
    public LanguageType LanguageType = LanguageType.Chinese;
}
