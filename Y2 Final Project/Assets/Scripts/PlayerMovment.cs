using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour, ISpawnRandomPoint
{
    [SerializeField] GameObject Player;
    [SerializeField] Transform SpawnPoint1;
    [SerializeField] Transform SpawnPoint2;
    [SerializeField] Transform SpawnPoint3;
    [SerializeField] Transform SpawnPoint4;

    [SerializeField] CharacterController _characterController;
    [SerializeField] Transform _camera;
    [SerializeField] float _movementSpeed = 4;

    float _turnSmoothTime = 0.1f;
    float _turnSmoothVelocity;

    private void Start()
    {
        SpawnAtRandomPoint(Player, SpawnPoint1, SpawnPoint2, SpawnPoint3, SpawnPoint4);
    }

    private void OnValidate()
    {
        if (TryGetComponent(out CharacterController cc))
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
        Vector3 direction = new Vector3(Horizontal, 0, Vertical).normalized;
        if (direction.magnitude >= 0.10f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 MoveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            _characterController.Move(MoveDir.normalized * _movementSpeed * Time.deltaTime);
        }
    }

    public void SpawnAtRandomPoint(GameObject PrefabToSpawn, Transform SpawnPoint1, Transform SpawnPoint2, Transform SpawnPoint3, Transform SpawnPoint4)
    {
        Transform[] spawnPoints = new Transform[] { SpawnPoint1, SpawnPoint2, SpawnPoint3, SpawnPoint4};
        int RandomIndex = Random.Range(0, spawnPoints.Length);
        PrefabToSpawn.transform.position = new Vector3(spawnPoints[RandomIndex].position.x, Player.transform.position.y, spawnPoints[RandomIndex].position.z + 4);
    }
}

