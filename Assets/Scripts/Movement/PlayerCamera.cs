using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public CinemachineVirtualCamera cam;
    private CinemachineConfiner2D _camConfiner;
    private void Start()
    {
        cam = GameObject
                .FindGameObjectWithTag("Camera")
                .GetComponent<CinemachineVirtualCamera>();
        if (cam == null)
        {
            Debug.LogError("Error: No Camera found in scene");
        }
        _camConfiner = cam.GetComponent<CinemachineConfiner2D>();
    }
    public void setConfines(BoxCollider2D collider, Transform lookat)
    {
        cam.Follow = lookat;
        _camConfiner.m_BoundingShape2D = collider;
    }
}
