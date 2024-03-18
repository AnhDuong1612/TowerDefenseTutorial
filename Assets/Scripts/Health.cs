using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int hitPoints = 2;
    [SerializeField] private int currencyWorth = 50;



    private bool isDestroy = false;

    public void TakeDamage(int dmg)
    {
        hitPoints -= dmg;
        if(hitPoints<=0 && !isDestroy)
        {
            EnemySpawner.onEnemyDestroy.Invoke();
            isDestroy = true;
            Destroy(gameObject);
            LevelManager.main.IncreaseCurrency(currencyWorth);
        }

    }


}
