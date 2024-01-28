using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputsManager : MonoBehaviour
{
    private PlayerInputs playerInputs;

    public Vector3 MoveVector3D { get { return GetMoveVector(); } }
    public Vector2 RotationVector2D { get { return playerInputs.Player_Map.Look.ReadValue<Vector2>(); } }
    public Vector3 RotationVector3D { get 
        {
            return new Vector3(
                playerInputs.Player_Map.Look.ReadValue<Vector2>().x,
                transform.position.y,
                playerInputs.Player_Map.Look.ReadValue<Vector2>().y);
        } 
    }

    public bool IsShooting { get { return playerInputs.Player_Map.Shoot.IsPressed(); } } 

    private bool isKeyboard = false;

    private void Awake()
    {
        playerInputs = new PlayerInputs();
        playerInputs.Enable();

#if UNITY_STANDALONE_WIN || UNITY_EDITOR
        isKeyboard = true;
#endif
    }

    private Vector3 GetMoveVector()
    {
        if (!isKeyboard) return new Vector3(); //TODO replace with platform

        float vertical = 0;
        float horizontal = 0;

        if (playerInputs.Player_Map.MoveDown.IsPressed())
            vertical -= 1;
        if (playerInputs.Player_Map.MoveUP.IsPressed())
            vertical += 1;
        if (playerInputs.Player_Map.MoveLeft.IsPressed())
            horizontal -= 1;
        if (playerInputs.Player_Map.MoveRight.IsPressed())
            horizontal += 1;

        return new Vector3(horizontal, 0, vertical);
    } 
}
