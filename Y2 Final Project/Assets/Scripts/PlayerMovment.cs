using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] CharacterController _characterController;
    [SerializeField] Transform _camera;
    [SerializeField] float _movementSpeed = 4;
    
    float _turnSmoothTime = 0.1f;
    float _turnSmoothVelocity;

    private void OnValidate()
    {
        if(TryGetComponent(out CharacterController cc))
        {
            _characterController ??= cc;
        }
    }


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
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity,_turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f,angle,0f);

            Vector3 MoveDir = Quaternion.Euler(0f,targetAngle,0f) * Vector3.forward;
            _characterController.Move(MoveDir.normalized*_movementSpeed*Time.deltaTime);
        }
    }
}
