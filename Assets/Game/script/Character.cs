using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private CharacterController _cc;

    public float MoveSpeed = 5f;

    private Vector3 _movementVelocity;

    //access to the PlayerInput script
    private PlayerInput _playerInput;

    private float _verticalVelocity;

    private float Gravity = -9.8f;

    private Animator _animator;

    //getting and storing references to the character controller
    // an Awake function is a built in unity function (its called before the start function)
    private void Awake()
    {
        //holding references
        _cc = GetComponent<CharacterController>();
        _playerInput = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
    }
    //changing the velocity based on the player's input
    private void CalculatePlayerMovement()
    {
        _movementVelocity.Set(_playerInput.HorizontalInput, 0f, _playerInput.VerticalInput);
        _movementVelocity.Normalize(); //otherwise the player will move faster when its moving diagonally(this is a built in fct in vector3)
        _movementVelocity = Quaternion.Euler(0, -45f, 0) * _movementVelocity;//to rotate the movement velocity to match the camera view angle

        //the running animation
        _animator.SetFloat("Speed", _movementVelocity.magnitude);

        _movementVelocity *= MoveSpeed * Time.deltaTime;//to make the movements smooth across frames (Time.deltaTime is the time passed since last frame)

        if (_movementVelocity != Vector3.zero)
        { //to stop the character from snapping back to the default position
            transform.rotation = Quaternion.LookRotation(_movementVelocity); //to make the player rotate
        }

        //the fall animation
        _animator.SetBool("AirBorne", !_cc.isGrounded);
    }

    private void FixedUpdate()
    {
        CalculatePlayerMovement();

        //moving the player downwards when its not on the ground
        if (_cc.isGrounded == false)
        {
            _verticalVelocity = Gravity;
        }
        //the else statement here is used to keep the character grounded during the next frame because if we do nothing then the character will automatically be floating in the next frame
        else
        {
            _verticalVelocity = Gravity * 0.3f;
        }
        _movementVelocity += _verticalVelocity * Vector3.up * Time.deltaTime;
        _cc.Move(_movementVelocity);
    }
}
