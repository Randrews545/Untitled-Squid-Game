using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    CharacterController characterController;
    public float movementSpeed;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 rotation;
    public float smooth = 1f;
    private Quaternion targetRotation;
    public float rotateHelp;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        targetRotation = transform.rotation;
    }
    void Update()
    {
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(0, 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection * movementSpeed);
            if (Input.GetKey("a"))
            {
                targetRotation *= Quaternion.AngleAxis(-rotateHelp, Vector3.up);
            }
            else if (Input.GetKey("d"))
            {
                targetRotation *= Quaternion.AngleAxis(rotateHelp, Vector3.up);
            }
            this.transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * smooth * Time.deltaTime);
            
        }
        moveDirection.y -= 1f * Time.deltaTime;
        characterController.Move(moveDirection);
    }

}
