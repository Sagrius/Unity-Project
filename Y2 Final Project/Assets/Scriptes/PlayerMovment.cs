using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] PlayerInput PlayerController;
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform playerArrow;
    float rotationSpeed = 100;


    InputAction Move;
    int speed = 4;
    private void Start()
    {
        Move = PlayerController.actions.FindAction("Move");
    }

    private void Update()
    {
        MovePlayer();
        RotatePlayer();
        updateArrowDirection();
    }
    void updateArrowDirection()
    {
        playerTransform.eulerAngles = playerArrow.eulerAngles;
    }

    void MovePlayer()
    {
        Vector3 Direction = Move.ReadValue<Vector3>();

        transform.position += new Vector3(Direction.x, Direction.z, Direction.y) * speed * Time.deltaTime;
    }
    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(-Vector3.up*rotationSpeed*Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.E))
        {
        transform.Rotate(Vector3.up*rotationSpeed*Time.deltaTime);
        }
    }
}
