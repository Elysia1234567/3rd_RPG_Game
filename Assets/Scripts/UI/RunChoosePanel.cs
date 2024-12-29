using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Splines;
using UnityEngine.UI;

public class RunChoosePanel : BasePanel
{
    public override void HideMe()
    {
        //EventCenter.Instance.Claer(E_EventType.E_SceneDeleteItem);
        
    }

    public override void ShowMe()
    {
       
    }

    
    // Start is called before the first frame update
    void Start()
    {
        GetControl<Button>("Button1").onClick.AddListener(() =>
        {
            GameObject spline = Instantiate(ResMgr.Instance.Load<GameObject>("Prefreb/Spline"));
            GameObject classMates = ResMgr.Instance.Load<GameObject>("Prefreb/classMates");
            SplineAnimate[] animates = classMates.GetComponentsInChildren<SplineAnimate>();
            for (int i = 0; i < animates.Length; i++)
            {
                animates[i].Container = spline.GetComponent<SplineContainer>();
            }
            GameObject trueClassMates = Instantiate(classMates);
            EventCenter.Instance.AddEventListener(E_EventType.E_SceneDeleteItem, () =>
            {
                Destroy(trueClassMates);
                Destroy(spline);

            });
            UIMgr.Instance.HidePanel<RunChoosePanel>();

        });
        GetControl<Button>("Button2").onClick.AddListener(() =>
        {
            GameObject eightSpline = Instantiate(ResMgr.Instance.Load<GameObject>("Prefreb/8Spline"));
            GameObject classMates = ResMgr.Instance.Load<GameObject>("Prefreb/classMates");
            SplineAnimate[] animates = classMates.GetComponentsInChildren<SplineAnimate>();
            for (int i = 0; i < animates.Length; i++)
            {
                animates[i].Container = eightSpline.GetComponent<SplineContainer>();
            }
            GameObject trueClassMates = Instantiate(classMates);
            EventCenter.Instance.AddEventListener(E_EventType.E_SceneDeleteItem, () =>
            {
                Destroy(trueClassMates);
                Destroy(eightSpline);

            });
            UIMgr.Instance.HidePanel<RunChoosePanel>();
        });
        GetControl<Button>("Button3").onClick.AddListener(() =>
        {
            GameObject snackSpline = Instantiate(ResMgr.Instance.Load<GameObject>("Prefreb/snackSpline"));
            GameObject classMates = ResMgr.Instance.Load<GameObject>("Prefreb/classMates");
            SplineAnimate[] animates = classMates.GetComponentsInChildren<SplineAnimate>();
            for (int i = 0; i < animates.Length; i++)
            {
                animates[i].Container = snackSpline.GetComponent<SplineContainer>();
            }
            GameObject trueClassMates = Instantiate(classMates);
            EventCenter.Instance.AddEventListener(E_EventType.E_SceneDeleteItem, () =>
            {
                Destroy(trueClassMates);
                Destroy(snackSpline);

            });
            UIMgr.Instance.HidePanel<RunChoosePanel>();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
