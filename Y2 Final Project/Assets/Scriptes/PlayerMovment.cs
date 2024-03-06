using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] PlayerInput PlayerController;

    InputAction Move;
    int speed = 4;
    private void Start()
    {
        Move = PlayerController.actions.FindAction("Move");
    }

    private void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector3 Direction = Move.ReadValue<Vector3>();

        transform.position += new Vector3(Direction.x, Direction.z, Direction.y) * speed * Time.deltaTime;
    }
}
