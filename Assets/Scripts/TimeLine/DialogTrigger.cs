using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DialogTrigger : MonoBehaviour
{
    public PlayableDirector director;

    private bool hasTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(hasTrigger) { return; }
        director.Play();
        hasTrigger = true;
    }
}
