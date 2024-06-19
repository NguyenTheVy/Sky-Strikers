using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinBar : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI coinShopTxt;
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
        coinText.text = PlayerData.GetCoin().ToString();
        coinShopTxt.text = PlayerData.GetCoin().ToString();
    }

    

}
