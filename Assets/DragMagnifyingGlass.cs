using System;
using UnityEngine;

public class DragMagnifyingGlass : MonoBehaviour
{
    public Vector3 mousePosition;
    public Vector3 dragOffset;
    //public Camera mainCamera;

    //public Transform smallDog;
    //public Transform bigDog;
    //public Transform spriteMaskTransform;

    private void OnMouseDown()
    {
        
        dragOffset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }

    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition - dragOffset;
    }

    //private void Update()
    //{
    //    bigDog.position = smallDog.position * 2 - spriteMaskTransform.position;
    //}
}
