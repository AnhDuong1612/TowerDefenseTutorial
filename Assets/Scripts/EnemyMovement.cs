using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // tao mot bien kieu rigidbody va cho phep sua gia tri bien nay trong inspector
    [Header("References")] // Tao mot tieu de trong ínpector cua doi tuong
    [SerializeField] private Rigidbody2D rb; // cho phep hien thi mot bien private trong unity va co the sua duoc trong 

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;

    private Transform target;
    private int pathIndex = 0;

    // neu vat the di den cuoi duong di thi huy object con khong thi tiep tuc chay . Gan cho mot bien de no nhan dien vi tri muc tieu : target
    // Cach lay target la lay tu level.manager.main.path.Length (de tro duoc vao path thi phai khoi tao con tro this=main de bi nhan dien duoc doi tuong trong ham nao duoc goi
    // Vi chuyen dong nay con co huong nen ta phai dung ham direction . va khi mot vat chuyen dong ta phai tinh velocity . mot vat chuyen dong theo mot huong tinh velocity va direction
    // transform dung de tham chieu toi mot vi tri cu the cua doi tuong con direction dung de di chuyen theo huong mong muon tu vi tri nay sang vi tri khac 

    private void Start()
    {
        target = LevelManager.main.path[pathIndex];
    }

    private void Update()
    {
        if(Vector2.Distance(target.position,transform.position) <= 0.1f)
        {
            pathIndex++;

            if(pathIndex == LevelManager.main.path.Length)
            {
                // old
                EnemySpawner.onEnemyDestroy.Invoke();
                Destroy(gameObject);
                return;
            }
            else
            {
                target = LevelManager.main.path[pathIndex];
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }
}