using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomTrigger : MonoBehaviour
{
    public SpriteRenderer S;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  

     void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(11);
        if (other.gameObject.name == "Player1")
        {
            S.enabled = true;
        }
    }
  
}
