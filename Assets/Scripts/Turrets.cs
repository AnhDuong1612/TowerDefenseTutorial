using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class Turrest : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform turretRotationPoint;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private GameObject upgradeUI;
    [SerializeField] private Button upgradeBtn;

    [Header("Attributes")]
    [SerializeField] private float targetingRange = 5f;
    [SerializeField] private float rotationSpeed = 200f;
    [SerializeField] private float bps = 1f;
    [SerializeField] private int baseUpgradeCost = 100;

    private Transform target;
    private float timeUntilFire;

    private int level = 1;
    private float bpsBase;
    private float targetingRangeBase;

    private void Start()
    {
        //bpsBase = bps;
        //targetingRangeBase = targetingRange;


        // Se luon khoi chay khi ma an vao nut an 
        upgradeBtn.onClick.AddListener(Upgrade);
    }


    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }

        RotateTowardsTarget();

        if (!CheckTargetIsInRange())
        {
            target = null;
        }
        else
        {
            timeUntilFire += Time.deltaTime;
            if (timeUntilFire >= 1f / bps)
            {
                Shoot();
                timeUntilFire = 0f;

            }
        }
    }

    private void Shoot()
    {
        //GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        //// Truy cap vao class khac voi kieu bullet thong qua GetComponent 
        //Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        //bulletScript.SetTarget(target);

        // khoi tao mot doi tuong ten la bulletObj la cac ban sao cua bulletPrefab duoc sinh ra tai vi tri firingPoint va khong co diem xoay co dinh 
        GameObject bulletObj = Instantiate(bulletPrefab,firingPoint.position,Quaternion.identity);
        // Bulletobj su dung de tham chieu den gameobj ma ban muon lay ra ,su dung de lay ra thanh phan co kieu cu the tu game object 
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(target);
        
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);
        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }

    private bool CheckTargetIsInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

    private void RotateTowardsTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        turretRotationPoint.rotation = Quaternion.RotateTowards(turretRotationPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);

    }

    public void OpenUpgradeUI()
    {
        upgradeUI.SetActive(true);
    }

    public void CloseUpgradeUI()
    {
        upgradeUI.SetActive(false);
        UIManager.main.SetHoveringState(false);
    }

    // Neu UIMa dang duoc hien len thi dung cac ham ben duoi lai
    // 

    private void OnDrawGizmos()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }

    public void Upgrade()
    {
        //if (baseUpgradeCost > LevelManager.main.currency) return;
        //LevelManager.main.SpendCurrency(CalculateCost());

        //level++;

        //bps = CalculateBPS();
        //targetingRangeBase = TargetingRange();

        CloseUpgradeUI();
        //Debug.Log("New BPS : " + bps);
        //Debug.Log("New BPS : " + targetingRange);
        //Debug.Log("New Cost : " + CalculateCost());

    }

    //private int CalculateCost()
    //{
    //    return Mathf.RoundToInt(baseUpgradeCost*Mathf.Pow(level,0.8f));
    //}

    //private float CalculateBPS()
    //{
    //    return Mathf.RoundToInt(bpsBase*Mathf.Pow(level,0.6f));
    //}

    //private float TargetingRange()
    //{
    //    return Mathf.RoundToInt(targetingRangeBase * Mathf(level, 0.4f));
    //}
}
//  Cai dat su kien dong mo thanh phan

// Nghien cuu nang cap thap chon thap



// Buoc mot cai dat giao dien sao cho no hien thi 