using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBase : MonoBehaviour
{
    [Header("UI组件")]
    public Text textLabel;
    public Image faceImage;

    [Header("文本文件")]
    public TextAsset textFile;
    public List<ScriptData> scriptDatas;
    public int index;//当前读取的条数
    public int count;//文件总共有的长度

    private void HandleData()
    {
        if (index >= count)
        {
            Debug.Log("对话结束");
        }
    }


    /// <summary>
    /// 加载下一条剧情数据
    /// </summary>
    private void LoadNextScript()
    {
        index++;
    }
}

/// <summary>
/// 剧本数据类
/// </summary>
public class ScriptData
{
    public int charpterId;//章节序号
    public int id;//对话序号
    public int type;//对话类型(1.正常对话 2.选项内容 3.结束对话)
    public int nexId;//下一个选项的id(主要还是用在选项上)
    public string name;//角色名称
    public string spriteName;//图片资源路径
    public string musicName;//背景音乐路径
    public string effectName;//特效路径
    public int eventId;//用于判断接下来的执行什么事件
    public bool isVible;//是否震屏
    public string soundName;//音效路径
}
