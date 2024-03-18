using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private int bulletDamage = 1;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    private void FixedUpdate()
    {
        if(!target) return;
        Vector2 direction = target.position - transform.position;
        rb.velocity = bulletSpeed * direction;
    }

    // xu ly va cham giua 2 vat 
    private void OnCollisionEnter2D(Collision2D other)
    {
        // Take health from enemy
        other.gameObject.GetComponent<Health>().TakeDamage(bulletDamage);
        Destroy(gameObject);
    }


}
