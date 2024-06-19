using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiShopElement : MonoBehaviour
{
   
    public int cost;
    public TextMeshProUGUI costTxt;
    public Button purchasBtn;
    public GameObject coinImg;
    public int id;

    private string path = "ShopItem/P_";
    private GameObject prefab;
    private GameObject airItem;

    private void Awake()
    {
        if(purchasBtn != null)
            purchasBtn.onClick.AddListener(OnPurchase);
        
    }

    public void SetData(int id)
    {
        this.id = id;
        cost = id * 100;
        InitAir();
        UpdateView();
    }

    private void InitAir()
    {
        prefab = Resources.Load<GameObject>(path + id);
        airItem = Instantiate(prefab, transform);
    }

    public void UpdateView()
    {
        
        // check xem air co dang su huu khong
        var isOwned = PlayerData.IsOwnedAirWithId(id);

        // neu so huu thi khong cho mua va nguoc lai
        if(isOwned)
        {
            purchasBtn.enabled = false;
            costTxt.text = "Owned";
            ChangeButtonColor();
            coinImg.SetActive(false);
        }
        else
        {
            purchasBtn.enabled = true;
            costTxt.text =  cost.ToString();

        }
        

        
    }
    public void OnPurchase()
    {
        var canPurchase = PlayerData.IsEnoughMoney(cost);
        if(canPurchase)
        {
            PlayerData.AddAir(id);
            UpdateView();
            PlayerData.SubCoin(cost);
            AudioController.Instance.PlaySound(AudioController.Instance.boughtItem);
        }
        else
        {
            Debug.Log("thieu tien");
            AudioController.Instance.PlaySound(AudioController.Instance.cantBoughtItem);

        }
    }

    public void ChangeButtonColor()
    {
        // Lấy thành phần Image của Button và đổi màu
        Image buttonImage = purchasBtn.GetComponent<Image>();
        if (buttonImage != null)
        {
            buttonImage.color = HexToColor("#bae5b9");
        }
    }

    public Color HexToColor(string hex)
    {
        hex = hex.Replace("#", "");
        byte a = 255;
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        return new Color32(r, g, b, a);
    }
}
