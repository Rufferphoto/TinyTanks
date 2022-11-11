using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TurretController : Controller
{
    [SerializeField] private Transform turretBase;
    [SerializeField] private float turretRotSpeed;
    
    
    private void FixedUpdate()
    {
        base.UpdateMousePos();

        Ray ray = cCamera.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance, ~ignoreMask))
        {
            Quaternion lookRotation = Quaternion.LookRotation(hit.point - turretBase.position);
            turretBase.rotation = Quaternion.Slerp(turretBase.rotation, lookRotation, turretRotSpeed * Time.deltaTime);
        }
    }

}
