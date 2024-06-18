using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiShopElement : MonoBehaviour
{
    public int id;
    public int cost;
    public TextMeshProUGUI costTxt;
    public Button purchasBtn;
    public GameObject coinImg;

    /*private GameObject prefab;
    private GameObject airItem;*/

    private void Awake()
    {
        purchasBtn.onClick.AddListener(OnPurchase);
        
    }

    public void SetData(int id)
    {
        this.id = id;
        cost = id * 100;
        //InitAir();
        UpdateView();
    }

    /*private void InitAir()
    {
        prefab = Resources.Load<GameObject>($"Air/{id}");
        airItem = Instantiate(prefab, transform);
    }*/

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
        PlayerData.AddAir(id);
        UpdateView();
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
