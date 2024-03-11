using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapFollow : MonoBehaviour
{
    [SerializeField] Transform Camera;
    [SerializeField] Transform Player;
    [SerializeField] int OffsetX;
    [SerializeField] int OffsetY;
    [SerializeField] int OffsetZ;

    // Update is called once per frame
    void Update()
    {
        Camera.position = new Vector3(Player.position.x+OffsetX,Player.position.y+OffsetY,Player.position.z+OffsetZ);
    }
}
