using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEditor;
using System;
using System.Threading;
public class BagPanel : BasePanel
{
    public Transform content;
    private List<ItemCell> cellList = new List<ItemCell>();
    public RectTransform panel;
    public override void HideMe()
    {
        //throw new System.NotImplementedException();
        InputMgr.Instance.StartOrCloseInputMgr(true);

    }

    public override void ShowMe()
    {
        for(int i = 0; i < cellList.Count; i++)
        {
            Destroy(cellList[i].gameObject);
        }
        cellList.Clear();
        for(int i = 0;i < PlayerMgr.Instance.objList.Count;i++)
        {
            //UIMgr.Instance.ShowPanel<ItemCell>(E_UILayer.Middle, (cell) =>
            //{
            //    item = (ItemCell)cell;
            //    item.transform.parent = content.transform;
            //    item.InitInfo(PlayerMgr.Instance.objList[0]);
            //});
            ABResMgr.Instance.LoadResAsync<GameObject>("ui", "ItemCell", (cell) =>
            {
               GameObject CellObj = GameObject.Instantiate(cell, content, false);
                CellObj.GetComponent<ItemCell>().InitInfo(PlayerMgr.Instance.objList[i]);
                cellList.Add(CellObj.GetComponent<ItemCell>());
            });

        }
        InputMgr.Instance.StartOrCloseInputMgr(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void ClickBtn(string btnName)
    {
        switch (btnName)
        {
            case "ReturnBtn":

                StartCoroutine("enumerator");


                break;
        }
    }
    IEnumerator enumerator()
    {
        panel.DOAnchorPos(new Vector2(0, -800), 0.6f, false).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.5f);
        UIMgr.Instance.HidePanel<BagPanel>();



    }

}
