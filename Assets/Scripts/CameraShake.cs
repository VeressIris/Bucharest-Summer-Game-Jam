using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance {  get; private set; }

    private CinemachineVirtualCamera virtualCam;
    private float shakeTimer;
    private CinemachineBasicMultiChannelPerlin cbmp;

    void Awake()
    {
        Instance = this;

        virtualCam = GetComponent<CinemachineVirtualCamera>();
        cbmp = virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    void Start()
    {
        cbmp.m_AmplitudeGain = 0f; //make sure the cam doesn't shake on load
    }

    public void ShakeCamera(float intensity, float time)
    {
        cbmp.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }

    private void Update()
    {
        if (shakeTimer > 0f) 
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                cbmp.m_AmplitudeGain = 0f;
            }
        }
    }
}
