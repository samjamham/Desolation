using System;
using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovementControls : MonoBehaviour
{

    [Range(0.0f, 10.0f)]
    public float speedModifier = 1f;
    [Range(0.0f, 10.0f)]
    public float JumpForce = 1.0f;

    private Vector2 moveInput;
    private float Gravity;
    private float yVelocity;
    private Vector3 xzVelocity;
    private bool Dojump; 

    [SerializeField]
    private CharacterController myCharacterController;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Gravity = -0.00981f * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector3 MoveDirection = new Vector3(0, 0, 0);
        xzVelocity = this.transform.forward * moveInput.y + this.transform.right * moveInput.x;
        MoveDirection += xzVelocity;

        if (myCharacterController.isGrounded && Dojump)
        {
            yVelocity = JumpForce * 0.1f;
            Dojump = false;
        }

        MoveDirection.y += yVelocity;

        myCharacterController.Move(MoveDirection);

        if (!myCharacterController.isGrounded)
            yVelocity += Gravity;
        else
            yVelocity = 0;
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        moveInput *= speedModifier;
    }

    void OnJump(InputValue value)
    {
        if (!Dojump)
        {
            Dojump = true;
            StartCoroutine(JumpBuffer());
        }
    }

    IEnumerator JumpBuffer()
    {
        yield return new WaitForSeconds(0.1f);
        Dojump = false;
    }

    public Action MoveToNextShift;
    void OnNextShift(InputValue value)
    {
        MoveToNextShift?.Invoke();
    }
}
