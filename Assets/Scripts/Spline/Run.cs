using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UI;

public class Run : MonoBehaviour
{
    private SpriteRenderer renderer;
    private SplineAnimate animate;
    public SplineAnimate[] classMatesAni;
    
    public int round;
    private bool isArrive;
    private bool isFail;
    public Vector3 pre;
    //public Vector3 offset;
    public Vector3 initPos;
   
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        animate = GetComponent<SplineAnimate>();
       //animate.Container=
        classMatesAni=this.transform.parent.GetComponentsInChildren<SplineAnimate>();
        initPos=transform.parent.Find("search").transform.position;
        //Debug.Log(initPos);
        pre =this.transform.position;
        round = 0;
        isArrive=false;
        isFail = false;
    }

    // Update is called once per frame
    void Update()
    {
        //print("时间" + animate.Duration);//一次的总时间
        //print(animate.ElapsedTime);//经过的时间
        if(!isArrive&&animate.ElapsedTime/animate.Duration >=2&&this.transform.tag=="head" )
        {
            isArrive = true;
            transform.parent.Find("search").GetComponent<SearchPlayer>().isPause=true;
            for (int i = 0; i < classMatesAni.Length; i++)
            {
                classMatesAni[i].Pause();
            }
            UIMgr.Instance.HidePanel<WarnPanel>(true);

            UIMgr.Instance.ShowPanel<WarnPanel>(E_UILayer.System,(obj)=>
            {
                if (transform.parent.Find("search").GetComponent<SearchPlayer>().hasLeave == false)
                {
                    obj.Init(1, new string[] { "10" });
                    //加服从度的逻辑
                }
                obj.InitStatic(3,"退出跑操",()=>
                {
                   
                    StartCoroutine(ExitGame());
                });
                
            });
        }
        if (!isFail&&transform.parent.Find("search").GetComponent<SearchPlayer>().failNum==2&&this.transform.tag=="head")
        {
            isFail = true;
            transform.parent.Find("search").GetComponent<SearchPlayer>().isPause = true;
            for (int i = 0; i < classMatesAni.Length; i++)
            {
                classMatesAni[i].Pause();
            }
            UIMgr.Instance.HidePanel<WarnPanel>(true);

            UIMgr.Instance.ShowPanel<WarnPanel>(E_UILayer.System, (obj) =>
            {
                //obj.Init(1, new string[] { "10" });
                obj.InitStatic(5, "退出跑操", () =>
                {
                    
                    StartCoroutine(ExitGame());

                });

            });
        }
        if (this.transform.position.x > pre.x)
        {
            renderer.flipX = false;
        }
        else
        {
            renderer.flipX = true;
        }
        pre = this.transform.position;
    }
    

    IEnumerator ExitGame()
    {
        UIMgr.Instance.GetPanel<ChangePanel>((cp) =>
        {
            cp.HideMe();
        });
        yield return new WaitForSeconds(1f);
        EventCenter.Instance.EventTrigger(E_EventType.E_SceneDeleteItem);
        EventCenter.Instance.Claer(E_EventType.E_SceneDeleteItem);
        UIMgr.Instance.GetPanel<ChangePanel>((cp) =>
        {
            cp.ShowMe();
        });
        UIMgr.Instance.HidePanel<WarnPanel>(true);
        InputMgr.Instance.StartOrCloseInputMgr(true);
    }

    IEnumerator RestartGame()
    {
        UIMgr.Instance.GetPanel<ChangePanel>((cp) =>
        {
            cp.HideMe();
        });
        
        yield return new WaitForSeconds(1f);

        UIMgr.Instance.GetPanel<ChangePanel>((cp) =>
        {
            cp.ShowMe();
        });
        transform.parent.Find("search").GetComponent<SearchPlayer>().render.color = Color.green;
        EventCenter.Instance.EventTrigger<Vector3>(E_EventType.E_Player_ChangePos,initPos );
        transform.parent.Find("search").GetComponent<SearchPlayer>().isPause = false;
        Debug.Log("已执行");
        for (int i = 0; i < classMatesAni.Length; i++)
        {
            classMatesAni[i].Restart(true);
        }
        InputMgr.Instance.StartOrCloseInputMgr(true);
        UIMgr.Instance.HidePanel<WarnPanel>(true);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.tag=="Player")
        {
            transform.parent.Find("search").GetComponent<SearchPlayer>().isPause = true;
            transform.parent.Find("search").GetComponent<SearchPlayer>().failNum = 0;
            transform.parent.Find("search").GetComponent<SearchPlayer>().timer = 0;
            for (int i = 0; i < classMatesAni.Length; i++)
            {
                classMatesAni[i].Pause();
            }
            UIMgr.Instance.HidePanel<WarnPanel>(true);
            UIMgr.Instance.ShowPanel<WarnPanel>(E_UILayer.System, (obj) =>
            {

                obj.InitStatic(4, "重新开始", () =>
                {
                    StartCoroutine(RestartGame());
                });

            });
            //StartCoroutine(RestartGame());
        }
    }
}
