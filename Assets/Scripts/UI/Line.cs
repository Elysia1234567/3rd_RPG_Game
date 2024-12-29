using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[ExecuteInEditMode]
public class Line : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform pointA;
    public Transform pointB;
    public Transform pointC;
    public Transform pointD;
    public Spline spline;

    internal List<Vector3> BezierIntepolate4List(Vector3 p0,Vector3 p1,Vector3 p2,Vector3 p3,float pointCount)
    {
        List<Vector3> pointList=new List<Vector3>();

        //for(int i = 0; i < pointCount; i++)
        //{

        //}
        return pointList;
    }

    private void Update()
    {
        //List<Vector3> path = BezierUtility.BezierPoint(pointA.position, pointB.position, pointC.position, pointD.position, 40);
    }
}
