using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
/// <summary>
/// 此脚本用于实现受击摄像机震动
/// </summary>
public class CameraShake : MonoBehaviour
{
   
    private CinemachineVirtualCamera CinemachineVirtualCamera;
    public float ShakeIntensity = 4f;
    public float ShakeTime = 0.5f;
    public bool isShake=false;

    public float timer;
    private CinemachineBasicMultiChannelPerlin _cbmcp;

    private void Awake()
    {
        CinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    private void Start()
    {

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(GameObject.Find("Main Camera"));

        //ShakeIntensity = 2f * GameMgr.Instance.VibValue;
        StopShake();
        EventCenter.Instance.AddEventListener(E_EventType.E_Camera_Shake,Shake);
    }
    public void ShakeCamera()
    {
        CinemachineBasicMultiChannelPerlin _cbmcp = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = ShakeIntensity * GameMgr.Instance.VibValue;

        timer = ShakeTime;
    }

    private void StopShake()
    {
        CinemachineBasicMultiChannelPerlin _cbmcp = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        
        _cbmcp.m_AmplitudeGain = 0f;
        timer = 0;
        
    }

    public void Shake()
    {
        if(GameMgr.Instance.isVib)
        {
            isShake = true;
        }
        
    }
    private void Update()
    {
        if (isShake)
        {
            ShakeCamera();
            isShake=false;
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                StopShake();
                
            }
        }
    }
}
