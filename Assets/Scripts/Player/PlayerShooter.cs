using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private Transform bulletStart;
    [SerializeField] private PlayerInputsManager playerInputsManager;

    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float reload;

    private float time = 0;

    private void FixedUpdate()
    {
        time -= Time.deltaTime;

        if (playerInputsManager.IsShooting)
            Shoot();
    }

    private void Shoot()
    {
        if (time > 0) 
            return;

        GameObject obj = Instantiate(bulletPrefab, bulletStart);
        BulletController bullet = obj.GetComponent<BulletController>();

        bullet.Shoot(bulletStart.forward.normalized);

        time = reload;
    }
}
