using Game_Fly;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection : MonoBehaviour
{
    //public int currentAirIndex;
    //public List<int> airList;
    public int currentAir;
    public GameObject[] prefabPlayer;
    public GameObject player;
    

    private void Start()
    {
        currentAir = PlayerData.GetCurrentAir();
        InitPlayer();
    }
    

    private void InitPlayer()
    {      
        player = GameObject.Instantiate(prefabPlayer[currentAir], transform);
        player.transform.localPosition = new Vector3(0f, -7f, 0f);
    }
}
