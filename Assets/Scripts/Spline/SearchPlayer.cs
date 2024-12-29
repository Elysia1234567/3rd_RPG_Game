using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Splines;

public class SearchPlayer : MonoBehaviour
{
    public SpriteRenderer render;
    public Tweener myTween;
    public float timer;
    private bool isOut;//角色是否在绿框外
    public bool isPause;//是否是暂停情况
    public SplineAnimate animate;
    public int failNum;//超过3秒的次数
    public bool hasLeave;//是否离开过绿框范围
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.position);
        animate = GetComponent<SplineAnimate>();
       render=this.GetComponent<SpriteRenderer>();
        myTween=render.DOColor(Color.red, 3);
        myTween.Play();
        timer = 0;
        isOut = true;
        isPause = false;
        failNum = 0;
        hasLeave = false;
        //animate.Restart(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
       if(isOut&&!isPause)
       {
            timer += Time.deltaTime;
            if(timer>1.5f)
            {
                hasLeave = true;
            }
       }
       if(timer>=3&&!isPause)
       {
            UIMgr.Instance.ShowPanel<WarnPanel>(E_UILayer.System,(obj)=>
            {
                obj.Init(2, new string[] {"-10"});
                render.color = Color.green;
                myTween = render.DOColor(Color.red, 3);
                myTween.Play();
                timer = 0;
                failNum++;
            });
       }
       if(isPause)
        {
            myTween.Pause();    
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            myTween.Kill();
            render.color = Color.green;
            isOut=false;
            timer = 0;
        }
           
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            myTween.Kill();
            render.color = Color.green;
            isOut=false;
            timer = 0;
        }
            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            myTween= render.DOColor(Color.red, 3);
            myTween.Play();
            isOut = true;
           
        }
        
    }


}
