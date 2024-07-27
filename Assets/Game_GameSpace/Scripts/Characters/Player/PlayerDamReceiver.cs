using Game_Fly;
using System.Collections;
using System.Collections.Generic;
using TigerForge;
using UnityEngine;

public class PlayerDamReceiver : DamageReceiver
{
    [SerializeField]
    protected GameObject bloodObj;

    protected override void OnEnable()
    {
        base.OnEnable();
        EventManager.StartListening(EventConstants.ADD_HP_PLAYER, AddHPPlayer);
    }

    private void AddHPPlayer()
    {
        int hpAdd = EventManager.GetInt(EventConstants.ADD_HP_PLAYER);
        Add(hpAdd);
    }

    protected override void OnDead()
    {
        if (GameManager.Instance.gamePlayManager.isWin) return;
        Instantiate(bloodObj, transform.position, Quaternion.identity);
        AudioController.Instance.PlaySound(AudioController.Instance.gameover);
        transform.parent.gameObject.SetActive(false);
        GameManager.Instance.gamePlayManager.ChangeStateEndGame(LevelResult.Lose);
        
    }

    public override void Deduct(float deduct)
    {
        base.Deduct(deduct);
        EventManager.SetData(EventConstants.UPDATE_HP_PLAYER, Hp);
        EventManager.EmitEvent(EventConstants.UPDATE_HP_PLAYER);
    }

    private void OnDisable()
    {
        EventManager.StopListening(EventConstants.ADD_HP_PLAYER, AddHPPlayer);
    }
}