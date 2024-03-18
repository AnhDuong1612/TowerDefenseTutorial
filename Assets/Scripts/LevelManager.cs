using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public Transform startPoint;
    public Transform[] path;
    public int currency;

    // khong co ham awake thi se khong nhan dien duoc danh sach path o dau . Can co ham awake de gan con tro cho main de cac lop khac hieu main la gi 
    private void Awake()
    {
        main = this;
    }
    private void Start()
    {
        currency = 100;
    }
    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }

    public bool SpendCurrency(int amount)
    {
        if(amount<=currency)
        {
            currency -= amount;
            return true;
        }
        else
        {
            Debug.Log("you do not have enough to pruchase this item");
            return false;

        }
    }
}
