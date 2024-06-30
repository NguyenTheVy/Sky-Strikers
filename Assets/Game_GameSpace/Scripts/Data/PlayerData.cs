using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
// khoi tao mac dinh du lieu cho user
public static class PlayerData
{
    private const string All_Data = "all_data";
    private static AllData allData;
    private static UnityEvent updateCoinEvent = new UnityEvent();
    static PlayerData()
    {
        //chuyen doi du lieu tu json sang Alldata
        allData = JsonUtility.FromJson<AllData>(PlayerPrefs.GetString(All_Data));

        //neu du lieu dau vao = null, tuc la user vao lan dau
        //chung ta can phai khoi tao du lieu cho user
        if (allData == null)
        {
            var airDefaultId = 1;
            allData = new AllData
            {
                airList = new List<int>() { airDefaultId },
                currentAir = airDefaultId,
                coin = 1000,
            };

            SaveData();
        }
    }

    public static void AddListener(UnityAction updateCoin)
    {
        updateCoinEvent.AddListener(updateCoin);
    }

    public static void RemoveListener(UnityAction updateCoin)
    {
        updateCoinEvent.RemoveListener(updateCoin);
    }

    private static void SaveData()
    {
        var data = JsonUtility.ToJson(allData);
        PlayerPrefs.SetString(All_Data, data);

    }

    public static bool IsOwnedAirWithId(int id)
    {
        return allData.IsOwnedAirWithId(id);
    }

    public static void AddAir(int id)
    {
        allData.AddAir(id);

        SaveData();
    }

    public static int GetCurrentAir()
    {
        return allData.GetCurrentAir();
    }

    public static void SetCurrentAir(int currentAir)
    {
        allData.SetCurrentAir(currentAir);

    }

    public static int GetPrevAirId()
    {
        var currentIndex = allData.GetPrevAirId();
        SaveData();
        return currentIndex;

    }
    public static int GetNextAirId()
    {
        var currentIndex = allData.GetNextAirId();
        SaveData();
        return currentIndex;

    }

    public static int GetCoin()
    {
        return allData.GetCoin();
    }

    public static void AddCoin(int value)
    {
        allData.AddCoin(value);
        updateCoinEvent?.Invoke();
        SaveData();
    }

    public static void SubCoin(int value)
    {
        allData.SubCoin(value);
        updateCoinEvent?.Invoke();
        SaveData();
    }

    public static bool IsEnoughMoney(int cost)
    {
        return allData.IsEnoughMoney(cost);
    }


}



public class AllData
{
    public List <int> airList;
    public int currentAir;
    public int coin;

    public int GetCurrentAir()
    {
        return currentAir;
    }
    public void SetCurrentAir(int currentAir)
    {
        this.currentAir = currentAir;
    }
    public int GetPrevAirId()
    {
        var airId = 1;
        var currentIndex = airList.IndexOf(currentAir);
        if(currentIndex == 0)
        {
            airId = airList[airList.Count - 1];
        }
        else
        {
            airId = airList[currentIndex - 1];
        }
        currentAir = airId;
        
        return airId;
    }

    public int GetNextAirId()
    {
        var airId = 1;
        var currentIndex = airList.IndexOf(currentAir);
        if (currentIndex == airList.Count - 1)
        {
            airId = airList[0];
        }
        else
        {
            airId = airList[currentIndex + 1];
        }
        currentAir = airId;

        return airId;
    }
    public bool IsOwnedAirWithId(int id)
    {
        return airList.Contains(id);
    }

    public void AddAir(int id)
    {
        //co roi thi dung chua co thi them vao danh sach du lieu 
        if (IsOwnedAirWithId(id))
        {
            return;
        }

        airList.Add(id);    
    }


    public int GetCoin()
    {
        return coin;
    }

    public void AddCoin(int value)
    {
        coin += value;
    }

    public void SubCoin(int value)
    {
        coin -= value;
    }

    public bool IsEnoughMoney(int cost)
    {
        return coin >= cost;
    }

}
