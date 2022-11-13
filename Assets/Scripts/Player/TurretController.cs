using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TurretController : Controller
{
    [SerializeField] private Transform turretBase;
    [SerializeField] private float turretRotSpeed;
    [SerializeField] private FiringSystem firingSystem;



    private void Awake()
    {
        base.Init();
        InterfaceHandler.Instance.inputActions.PlayerTank.Fire.performed += Fire_performed;
    }

    private void Fire_performed(InputAction.CallbackContext obj)
    {
        firingSystem.Fire_performed(turretBase);
    }

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
