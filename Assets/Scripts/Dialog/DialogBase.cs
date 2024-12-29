using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBase : MonoBehaviour
{
    [Header("UI���")]
    public Text textLabel;
    public Image faceImage;

    [Header("�ı��ļ�")]
    public TextAsset textFile;
    public List<ScriptData> scriptDatas;
    public int index;//��ǰ��ȡ������
    public int count;//�ļ��ܹ��еĳ���

    private void HandleData()
    {
        if (index >= count)
        {
            Debug.Log("�Ի�����");
        }
    }


    /// <summary>
    /// ������һ����������
    /// </summary>
    private void LoadNextScript()
    {
        index++;
    }
}

/// <summary>
/// �籾������
/// </summary>
public class ScriptData
{
    public int charpterId;//�½����
    public int id;//�Ի����
    public int type;//�Ի�����(1.�����Ի� 2.ѡ������ 3.�����Ի�)
    public int nexId;//��һ��ѡ���id(��Ҫ��������ѡ����)
    public string name;//��ɫ����
    public string spriteName;//ͼƬ��Դ·��
    public string musicName;//��������·��
    public string effectName;//��Ч·��
    public int eventId;//�����жϽ�������ִ��ʲô�¼�
    public bool isVible;//�Ƿ�����
    public string soundName;//��Ч·��
}
