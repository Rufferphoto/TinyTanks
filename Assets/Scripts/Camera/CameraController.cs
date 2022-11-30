using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    protected Camera mCamera;


    // Variables
    [SerializeField] protected float rotationSpeed;

    protected void Awake()
    {
        mCamera = Camera.main;
    }
}
