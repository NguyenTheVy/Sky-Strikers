using Game_Fly;
using System.Collections;
using System.Collections.Generic;
using TigerForge;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyDamReceiver : DamageReceiver
{
    [SerializeField]
    protected GameObject bloodObj;
    [SerializeField]
    private EnemyType enemyType;
    [SerializeField]
    private Slider health;
    [SerializeField]
    protected Gradient gradient;
    [SerializeField]
    protected Image fill;
    [SerializeField] 
    protected int cost;


    public GameObject[] itemPrefab;
    public float dropProbability = 10f; // Tỉ lệ phần trăm
    private void Start()
    {
        if (health != null)
        {
            health.maxValue = maxHp;
            health.value = maxHp;

            fill.color = gradient.Evaluate(1f);

        }
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        EventManager.StartListening(EventConstants.UPDATE_HP_BOSS, UpdateHeathBoss);
    }

    private void UpdateHeathBoss()
    {
        if (health != null)
        {
            health.value = Hp;
            fill.color = gradient.Evaluate(health.normalizedValue);
            
        }

    }


    protected override void OnDead()
    {
        
        if (enemyType == EnemyType.Boss)
        {
            GameManager.Instance.gamePlayManager.isWin = true;

            GameManager.Instance.IncreaseLevel(GameManager.Instance.levelPlaying);
            GameManager.Instance.isStartGame = true;
            Instantiate(bloodObj, transform.position, Quaternion.identity);
            AudioController.Instance.PlaySound(AudioController.Instance.bossDeath);
            transform.parent.gameObject.SetActive(false);

            PlayerData.AddCoin(cost);
            //Invoke("DelayDead", 3f);
            GameManager.Instance.UiController.OpenUiVictory();


        }
        if (enemyType == EnemyType.Normal)
        {
            
            Instantiate(bloodObj, transform.position, Quaternion.identity);
            AudioController.Instance.PlaySound(AudioController.Instance.enemyHit);
            transform.parent.gameObject.SetActive(false);
            if (Random.Range(0f, 100f) <= dropProbability)
            {
                Instantiate(itemPrefab[Random.Range(0, itemPrefab.Length)], transform.position, Quaternion.identity);
            }

            WaveSpawn.S_instance.OnEnemyDead?.Invoke();
            
        }
        
    }

    private void DelayDead()
    {
        SceneManager.LoadScene("Lobby");
    }



    private void OnDisable()
    {
        //StopCoroutine(DelayDead());
        EventManager.StopListening(EventConstants.UPDATE_HP_BOSS, UpdateHeathBoss);
    }
}

internal class OnEnable
{
}