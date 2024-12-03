using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    public GameObject WateR;
    public static GameController instance;
    public bool waterbucket, buffer;
    public int coin, paddy, flour, dough, cane, demand,CustomerCount,Amount;
    void Start()
    {
        instance = this; buffer = false;
        paddy = 0; flour = 0; dough = 0; cane = 0; coin = 0; waterbucket = false; demand = 7;CustomerCount = 0;
        WateR.SetActive(false);
    }
    public void IncreasePaddy()
    {
        paddy++;
        Debug.Log($"paddy: {paddy}, coins: {coin}, water: {waterbucket}");
    }

    public void ClearInventory()
    {
        paddy = 0; flour = 0; dough = 0; cane = 0;
    }
    public void GainCoin(int type,int amtt)
    {
        switch (type)
        {
            case 0:
                coin += paddy;
                paddy-=amtt;
                break;
            case 1:
                coin += 5 * flour;
                flour-=amtt;
                break;
            case 2:
                coin += 25 * dough;
                dough-=amtt;
                break;
            case 3:
                coin += 125 * cane;
                cane-=amtt;
                break;
        }
        Debug.Log($"paddy: {paddy}, coins: {coin}, water: {waterbucket}");
    }
    public void Unload()
    {
        int x = demand;
        int y = Amount;
        if (ProductAvailable(x,y))
        {
            GainCoin(x,y);
            demand = 7;
            Debug.Log("Customer satisfied!!");
            Debug.Log($"paddy: {paddy}, coins: {coin}, water: {waterbucket}");
        }
    }
    public int TryWater(int same)
    {
        if (waterbucket && same < 3)
        {
            waterbucket = false;
            WateR.SetActive(false);
            return 5;
        }
        else
        {
            return same;
        }
    }
    public void fillbucket()
    {
        waterbucket = true;
        WateR.SetActive(true);
    }
    public void QueueProduct(int want,int amt)
    {
        if (demand==7)
        {
            demand = want;
            Amount = amt;
        }
    }
    public bool ProductAvailable(int x,int y)
    {
        switch (x)
        {
            case 0:
                return paddy >= y ;
            case 1:
                return flour >=y;
            case 2:
                return dough >=y;
            case 3:
                return cane >=y;
            default:
                return false;
        }
    }
}
