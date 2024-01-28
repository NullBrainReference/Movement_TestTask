using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float timeOut;

    private void Start()
    {
        Destroy(gameObject, timeOut); //Bullet selfdestroy timeout
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");
        Destroy(gameObject);
    }

    public void Shoot(Vector3 dir) //Vector3.normalized
    {
        rb.velocity = dir * speed;
    }
}
