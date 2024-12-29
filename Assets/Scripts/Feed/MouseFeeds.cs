using MoreMountains.Feedbacks;
using MoreMountains.Feel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFeeds : MonoBehaviour
{
  
   
        public MMFeedbacks ClickFeedback;
    public void Update()
    {
        this.transform.position = Input.mousePosition;
        
    }





}
