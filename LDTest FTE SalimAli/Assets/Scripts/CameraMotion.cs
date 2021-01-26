using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMotion : MonoBehaviour
{
    public Vector3 zoomInOffset;
    public Vector3 zoomOutOffset;

    private CinemachineVirtualCamera vcam;


    public void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    public void ZoomIn()
    {
        var fTransposer = vcam.GetCinemachineComponent<CinemachineFramingTransposer>();
        fTransposer.m_TrackedObjectOffset = zoomInOffset;
    }

    public void ZoomOut()
    {
        var fTransposer = vcam.GetCinemachineComponent<CinemachineFramingTransposer>();
        fTransposer.m_TrackedObjectOffset = zoomOutOffset;
    }

}
