using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinBarViktory : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    
    public int cost;

    private void OnEnable()
    {
        PlayerData.AddListener(UpdateView);
    }

    private void OnDisable()
    {
        PlayerData.RemoveListener(UpdateView);
    }

    private void Start()
    {
        UpdateView();
    }
    public void UpdateView()
    {

        coinText.text = cost.ToString();

    }



}
