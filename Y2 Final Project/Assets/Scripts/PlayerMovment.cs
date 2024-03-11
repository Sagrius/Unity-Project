using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] CharacterController CharacterController;
    [SerializeField] Transform Camera;
    [SerializeField] int Movementspeed = 4;
    float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;


    private void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(Horizontal,0,Vertical).normalized;
        if (direction.magnitude >= 0.10f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f,angle,0f);

            Vector3 MoveDir = Quaternion.Euler(0f,targetAngle,0f) * Vector3.forward;
            CharacterController.Move(MoveDir.normalized*Movementspeed*Time.deltaTime);
        }
    }
}
