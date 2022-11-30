using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BaseController : Controller
{
    // Used to store player input.
    private Vector2 movementInput;

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

    private void TankMovement()
    {
        controller.Move(Vector3.forward * (movementInput.y * movementSpeed * Time.deltaTime)); // Swap vector3.forward to transform.forward to link with transform rotation.
        controller.Move(Vector3.right * movementInput.x * movementSpeed * Time.deltaTime);
        controller.Move(Vector3.up * gravity * Time.deltaTime);


        Vector3 tmp = transform.TransformPoint(Vector3.left * offset);
        Vector3 dir = tmp - leftLast;
        float spd = dir.magnitude / Time.deltaTime;
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
        rotationMovement = new Vector3(movementInput.x, 0, movementInput.y);
        rotationMovement.Normalize();

        if (rotationMovement != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(rotationMovement, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
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
