using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private PlayerInputsManager playerInputsManager;
    [SerializeField] private PlayerAnimationsController animationController;

    [SerializeField] private Rigidbody rb;

    [SerializeField] private float speed;
    [SerializeField] private float idleLimit;
    [SerializeField] private float sideLimit;

    [SerializeField] private LayerMask groundMask;

    private void FixedUpdate()
    {
        Aim();
        Move();
    }

    private void Move()
    {
         rb.velocity = speed * playerInputsManager.MoveVector3D.normalized * Time.deltaTime;

        CallAnimatation();
    }

    private void CallAnimatation()
    {
        if (rb.velocity.magnitude <= idleLimit && rb.velocity.magnitude >= -idleLimit)
        {
            animationController.PlayIdle();
            return;
        }

        float angle = Vector3.Angle(transform.forward, rb.velocity);

        Vector3 rightDirection = Vector3.Cross(transform.forward, Vector3.up);

        float angleRight = Vector3.SignedAngle(rb.velocity, rightDirection, Vector3.up);

        if (angleRight > 90 || angleRight < -90) // Определяем правую сторону
            angle = 360 - angle;

        int sector = (int)((angle + 22.5f) / 45); // Разбиваем круг на 8 секторов, девятый(8) побочный относится к первому(0) из-за "angle - 22.5"

        switch (sector)
        {
            case 0:
                animationController.PlayRun_Forward();
                break;
            case 1:
                animationController.PlayRun_Left();
                break;
            case 2:
                animationController.PlayStrafe_Left();
                break;
            case 3:
                animationController.PlayRun_BackwardLeft();
                break;
            case 4:
                animationController.PlayRun_Backward();
                break;
            case 5:
                animationController.PlayRun_BackwardRight();
                break;
            case 6:
                animationController.PlayStrafe_Right();
                break;
            case 7:
                animationController.PlayRun_Right();
                break;
            case 8:
                animationController.PlayRun_Forward();
                break;
        }
    }

    private void Aim()
    {
        var (success, position) = GetMousePosition();
        if (success)
        {
            var direction = position - transform.position;

            direction.y = 0;

            transform.forward = direction;
        }
    }

    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = Camera.main.ScreenPointToRay(playerInputsManager.RotationVector2D);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            return (success: true, position: hitInfo.point);
        }
        else
        {
            return (success: false, position: Vector3.zero);
        }
    }
}
