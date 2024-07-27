using System;
using System.Collections;
using System.Collections.Generic;
using TigerForge;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Presenter : MonoBehaviour
{
    public Button nextBtn;
    public Button prevBtn;

    [SerializeField] private int playerIndex;
    private string path = "Air/P_";
    private GameObject prefabPlayer;
    private GameObject player;
    private void Awake()
    {

        playerIndex = PlayerData.GetCurrentAir();
        nextBtn.onClick.AddListener(OnNext);
        prevBtn.onClick.AddListener(OnPrev);

    }

    

    private IEnumerator Start()
    {
        yield return InitPlayer();
    } 

    private IEnumerator InitPlayer()
    {
        var request = Resources.LoadAsync<GameObject>(path + playerIndex);
        while (!request.isDone)
        {
            yield return null;
        }
        prefabPlayer = (GameObject)request.asset;
        SetPlayer();
        


    }
   
    private void SetPlayer()
    {
        player = GameObject.Instantiate(prefabPlayer, transform);
        player.transform.localPosition = Vector3.zero;
        
    }

    private void OnNext()
    {
        AudioController.Instance.PlaySound(AudioController.Instance.click);
        Destroy(player);
        playerIndex = PlayerData.GetNextAirId();
        StartCoroutine(InitPlayer());
        
    }

    private void OnPrev()
    {
        AudioController.Instance.PlaySound(AudioController.Instance.click);
        Destroy(player);
        playerIndex = PlayerData.GetPrevAirId();
        StartCoroutine(InitPlayer());
    }

    

    

    


}
