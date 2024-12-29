using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zhenTanTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Button bt1;

    public Button bt2;
    public GameObject g1;
    public GameObject g2;

    public float a;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.gameObject.name == "Sprite Mask")
        {
            Debug.Log(11);
            StartCoroutine("enumerator");

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Sprite Mask")
        {
            Debug.Log(11);
            StopAllCoroutines();
            //g1.SetActive(false);
            //g2.SetActive(false);
        }
    }
    //void OnTriggerStay2D(Collider2D other)
    //{
    //    Debug.Log(11);

    //    if (other.gameObject.name == "Sprite Mask")
    //    {
    //        Debug.Log(11);

    //    }
    //}
    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log(22);
        //g1.SetActive(true);
        //g2.SetActive(true);
        UIMgr.Instance.GetPanel<DetectivePanel>((p) =>
        {
            p.GetControl<Image>("Image1 (5)").gameObject.SetActive(true);
            if(p.GetControl<Image>("Image1 (5)").gameObject.activeInHierarchy&& 
            p.GetControl<Image>("Image1 (6)").gameObject.activeInHierarchy&& 
            p.GetControl<Image>("Image1 (7)").gameObject.activeInHierarchy)
            {
                p.GetControl<Button>("confirm3").gameObject.SetActive(true);
            }

        });


    }
}
