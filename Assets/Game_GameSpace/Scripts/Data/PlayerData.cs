using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// khoi tao mac dinh du lieu cho user
public static class PlayerData
{
    private const string All_Data = "all_data";
    private static AllData allData;

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
            };

            SaveData();
        }
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
}



public class AllData
{
    public List <int> airList;
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

}
