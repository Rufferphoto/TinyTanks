using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    protected Mouse cMouse;
    protected Camera cCamera;
    protected Keyboard cKeyboard;
    protected Vector3 mousePos;

    [SerializeField] protected float rayDistance;
    [SerializeField] protected LayerMask ignoreMask;
    [SerializeField] protected float gravity;

    protected void Init()
    {
        cMouse = Mouse.current;
        cCamera = Camera.main;
    }

    protected void UpdateMousePos()
    {
        mousePos = cMouse.position.ReadValue();
        mousePos.z = rayDistance;
    }
}
