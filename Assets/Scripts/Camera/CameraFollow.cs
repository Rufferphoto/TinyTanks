using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : CameraController
{
    [SerializeField] private Transform target;
    private Quaternion lookRotation;

    private void FixedUpdate()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        lookRotation = Quaternion.LookRotation(target.position - mCamera.transform.position);

        if (lookRotation != mCamera.transform.rotation)
        {            
            mCamera.transform.rotation = Quaternion.Slerp(mCamera.transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
