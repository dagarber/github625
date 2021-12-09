using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MovementProvider : LocomotionProvider
{
    private float speed = 2.0f;
    private float gravityMultiplier = 0.5f; // set in editor if public
    public List<XRController> controllers = null;

    private float useGravity;
    private float jumpMultiplier = -0.5f;
    private CharacterController characterController = null;
    private GameObject head = null;

    protected override void Awake()
    {
        characterController = GetComponent<CharacterController>();
        head = GetComponent<XRRig>().cameraGameObject;
	}

    // Start is called before the first frame update
    void Start()
    {
        PositionController();
        useGravity = gravityMultiplier;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PositionController();
        CheckForInput();
        ApplyGravity();
    }

    private void PositionController()
    {
        float headHeight = Mathf.Clamp(head.transform.localPosition.y, 1, 2);
        characterController.height = headHeight;
        Vector3 newCenter = Vector3.zero;
        newCenter.y = characterController.height / 2;
        newCenter.y += characterController.skinWidth;
        newCenter.x = head.transform.localPosition.x;
        newCenter.z = head.transform.localPosition.z;
        characterController.center = newCenter;
	}

    private void CheckForInput()
    {
        foreach(XRController controller in controllers)
        {
            if(controller.enableInputActions)
                CheckForMovement(controller.inputDevice);
		}
	}

    private void CheckForMovement(InputDevice device)
    {
        if(device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position))
            StartMove(position);
        if (device.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue))
            if (primaryButtonValue)
                useGravity = jumpMultiplier;
            else
                useGravity = gravityMultiplier;
    }

    private void StartMove(Vector2 position)
    {
        Vector3 direction = new Vector3(position.x, 0, position.y);
        Vector3 headRotation = new Vector3(0, head.transform.eulerAngles.y, 0);
        direction = Quaternion.Euler(headRotation) * direction;
        Vector3 movement = direction * speed;
        characterController.Move(movement * Time.fixedDeltaTime);
	}

    private void Jump()
    {

    }

    private void ApplyGravity()
    {
        /*bool isGrounded = CheckIfGrounded();
        if (isGrounded)
            useGravity = 0;
        else
            useGravity = gravityMultiplier;*/

        Vector3 gravity = new Vector3(0, Physics.gravity.y * useGravity, 0);
        gravity.y *= Time.fixedDeltaTime;
        characterController.Move(gravity); // * Time.fixedDeltaTime);
	}

    /*bool CheckIfGrounded()
    {
        Vector3 rayStart = transform.TransformPoint(characterController.center);
        float rayLength = characterController.center.y + 0.01f;
        bool hasHit = Physics.SphereCast(rayStart, characterController.radius, Vector3.down, out RaycastHit hitInfo, rayLength);
        return hasHit;
    }*/

}
