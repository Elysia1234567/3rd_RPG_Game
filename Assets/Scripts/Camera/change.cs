using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class change : MonoBehaviour
{
    UnityAction<bool> cg;
    private void Cg(bool flag)
    {
        if(flag)
        {
            this.gameObject.SetActive(false);
        }
        else { this.gameObject.SetActive(true); }
    }
    // Start is called before the first frame update
    void Start()
    {
        cg = new UnityAction<bool>(Cg);
        EventCenter.Instance.AddEventListener(E_EventType.E_Cg, cg);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
