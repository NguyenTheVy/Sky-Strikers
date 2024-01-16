using Game_Fly;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TigerForge;
using UnityEngine;
using UnityEngine.UI;

public class UIGamePlay : UICanvas
{
    public static UIGamePlay Ins; 

    [Title("Button")] [SerializeField] private Button btnHide;
    [SerializeField] private Button btnPlayGame;
    [SerializeField] private Button btnExit;

    private bool isFistOpen;
    [SerializeField]
    private Text txtHp, txtLevel;
    public int countBullet = 1;

    protected override void Awake()
    {
        if (Ins == null)
            Ins = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
        SetDefaultTxtBulletPlayer();
    }

    private void OnEnable()
    {
        EventManager.StartListening(EventConstants.UPDATE_HP_PLAYER, UpdateHPPLayer);
        EventManager.StartListening(EventConstants.UPDATE_LV_PLAYER, UpdateLVPlayer);
    }

    private void SetDefaultTxtBulletPlayer()
    {
        txtLevel.text = countBullet.ToString();
    }

    private void UpdateHPPLayer()
    {
        txtHp.text = EventManager.GetFloat(EventConstants.UPDATE_HP_PLAYER).ToString();
    }

    public void UpdateLVPlayer()
    {
        if (countBullet >= 5) return;
        countBullet++;
        txtLevel.text = countBullet.ToString();
    }

    private void Exit()
    {
        OnBackPressed();
    }



    private void Init()
    {
    }

    public override void Show(bool _isShown, bool isHideMain = true)
    {
        base.Show(_isShown, isHideMain);
        if (IsShow)
        {
            Init();
        }
    }


    private void OnClickBtnPlay()
    {
        ShowAniHide();

    }

    public void ShowAniHide()
    {
        Show(false);
    }

    private void OnDisable()
    {
        EventManager.StopListening(EventConstants.UPDATE_HP_PLAYER, UpdateHPPLayer);
        EventManager.StopListening(EventConstants.UPDATE_LV_PLAYER, UpdateLVPlayer);
        PlayerDataManager.Instance.SetIndexWave(0);
    }
}
