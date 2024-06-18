using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presenter : MonoBehaviour
{
    
    private GameObject prefabPlayer;

    private GameObject player;
    public float timeDelay;

    private void Start()
    {

        SetPlayer();
    }

    private void SetPlayer()
    {
        player = GameObject.Instantiate(prefabPlayer, transform);
        player.transform.localPosition = Vector3.zero;
    }

    

    

    


}
