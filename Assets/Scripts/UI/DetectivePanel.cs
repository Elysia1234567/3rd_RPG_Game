using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectivePanel : BasePanel
{
    public override void HideMe()
    {
        InputMgr.Instance.StartOrCloseInputMgr(true);

    }

    public override void ShowMe()
    {
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
            case "ExitBtn":
                StartCoroutine("enumerator");

                break;
            case "confirm1":
                GetControl<Image>("Image1 (1)").gameObject.SetActive(false);
                GetControl<Image>("Image1 (2)").gameObject.SetActive(false);
                GetControl<Image>("result1").gameObject.SetActive(true);
                GetControl<Button>("confirm1").gameObject.SetActive(false);

                break;
            case "confirm2":
                GetControl<Image>("Image1 (3)").gameObject.SetActive(false);
                GetControl<Image>("Image1 (4)").gameObject.SetActive(false);
    
                GetControl<Image>("result2").gameObject.SetActive(true);
                GetControl<Button>("confirm2").gameObject.SetActive(false);

                break;
            case "confirm3":
                GetControl<Image>("Image1 (5)").gameObject.SetActive(false);
                GetControl<Image>("Image1 (6)").gameObject.SetActive(false);
                GetControl<Image>("Image1 (7)").gameObject.SetActive(false);

                GetControl<Image>("result3").gameObject.SetActive(true);
                GetControl<Button>("confirm3").gameObject.SetActive(false);

                break;
        }
    }
    IEnumerator enumerator()
    {
        //GameObject vC = GameObject.Find("Virtual Camera");
        //GameObject mC = GameObject.Find("Main Camera");
        //GameObject l2D = GameObject.Find("Lighting Manager 2D");

        //vC.SetActive(true);
        //mC.SetActive(true);
        //l2D.SetActive(true);
        //UIMgr.Instance.HidePanel<DetectivePanel>();
        //UIMgr.Instance.ShowPanel<GamePanel>();

        UIMgr.Instance.GetPanel<ChangePanel>((cp) =>
        {
            cp.HideMe();
        });
        yield return new WaitForSeconds(1f);
        GameObject player = GameObject.Find("Player1");
        player.transform.position = new Vector3(17, -1.2f, 0);
        yield return new WaitForSeconds(0.1f);
        //GameObject vC = GameObject.Find("Virtual Camera");
        //GameObject mC = GameObject.Find("Main Camera");
        //GameObject l2D = GameObject.Find("Lighting Manager 2D");

        //vC.SetActive(true);
        //mC.SetActive(true);
        //l2D.SetActive(true);
        //UIMgr.Instance.HidePanel<DetectivePanel>();
        //UIMgr.Instance.ShowPanel<GamePanel>();

        SceneMgr.Instance.LoadScene("GameScene2", () =>
        {

       
            UIMgr.Instance.GetPanel<ChangePanel>((cp) =>
            {
                cp.ShowMe();
                EventCenter.Instance.EventTrigger<bool>(E_EventType.E_Cg, false);

                UIMgr.Instance.HidePanel<DetectivePanel>();
                UIMgr.Instance.ShowPanel<GamePanel>(E_UILayer.System);
            });



        });
    }
}
