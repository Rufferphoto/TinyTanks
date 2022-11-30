using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BaseController : Controller
{
    // Used to store player input.
    private Vector2 movementInput;
    private Vector2 rotationInput;
    public float inputRot;

    // Serialized
    [SerializeField] CharacterController controller;
    [SerializeField] private float movementSpeed = 3f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float movementRot = 3f;
    [SerializeField] private TrackTextureAnimator leftTrack;
    [SerializeField] private TrackTextureAnimator rightTrack;
    Vector3 rotationMovement = new Vector3();


    // TEST implementation
    Vector3 leftLast;
    Vector3 rightLast;
    public float offset;


    private void OnEnable()
    {
        InterfaceHandler.Instance.inputActions.PlayerTank.Enable();
    }

    private void Awake()
    {
        base.Init();
    }

    public void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    public void OnRotate(InputValue value)
    {
        rotationInput = value.Get<Vector2>();
    }

    private void TankMovement()
    {
        controller.Move(transform.forward * movementInput.y * movementSpeed * Time.deltaTime); // Swap vector3.forward to transform.forward to link with transform rotation.
        // controller.Move(Vector3.right * movementInput.x * movementSpeed * Time.deltaTime);
        controller.Move(transform.up * gravity * Time.deltaTime);


        Vector3 tmp = transform.TransformPoint(Vector3.left * offset);
        Vector3 dir = tmp - leftLast;
        float spd = dir.magnitude / Time.deltaTime;
        if (Vector3.Dot(transform.forward, dir) < 0.0f)
        {
            spd *= -1;
        }
        leftTrack.speedY = spd;
        leftLast = tmp;

        tmp = transform.TransformPoint(Vector3.right * offset);
        dir = tmp - rightLast;
        spd = dir.magnitude / Time.deltaTime;
        if (Vector3.Dot(transform.forward, dir) < 0.0f)
        {
            spd *= -1;
        }
        rightTrack.speedY = spd;
        rightLast = tmp;
    }

    private void TankRotation()
    {
        inputRot += rotationMovement.x;
        rotationMovement = new Vector3(rotationInput.x, 0, 0); 
        

        if (rotationMovement != Vector3.zero)
        {
            if (inputRot == -360)
            {
                inputRot = 360;
            }
            if (inputRot == 360)
            {
                inputRot = -360;
            }

            Quaternion lookRotation = Quaternion.LookRotation(rotationMovement, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, inputRot * rotationSpeed, 0), Time.deltaTime);
        }
    }


    private void TankMovementB()
    {
        // update target speeds, then update actual speeds;

    }

    private void FixedUpdate()
    {
        TankMovement();
        TankRotation();
    }

    private void OnDestroy()
    {
        InterfaceHandler.Instance.inputActions.PlayerTank.Disable();
    }
}
