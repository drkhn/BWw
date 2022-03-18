using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Enums;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float camDuration;
    [SerializeField] float camStrength = 3;
    [SerializeField] Color screenColor;

    private void OnEnable()
    {
        EventManager.GameCamera += SetCamera;
    }
    private void OnDisable()
    {
        EventManager.GameCamera -= SetCamera;
    }

    public void SetCamera(CameraRoot value)
    {
        if (value == CameraRoot.FailCamera)
        {
            FailCamera();
        }
        else if (value == CameraRoot.SuccessCamera)
        {
            SuccessCamera();
        }
    }

    void FailCamera()
    {
        cam.DOShakePosition(camDuration, camStrength, fadeOut: true).OnComplete(() => cam.transform.position = new Vector3(0,0,-10));
        CameraColor(Color.red);
    }

    void SuccessCamera()
    {
        CameraColor(Color.green);
    }

    public void CameraColor(Color camColor)
    {
        cam.DOColor(camColor, .25f).OnComplete(() => cam.DOColor(screenColor, .25f));
    }
}
