using Game_Fly;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    [SerializeField]
    protected GameObject bossPrefab, miniBoss;

    [SerializeField]
    protected GameObject effect;
    
    [SerializeField]
    protected Transform pos1, pos2;

    [SerializeField]
    float timeDelay;

    [SerializeField]
    private EnemyType enemyBossType;

    public int countEnemy = 0;
    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private void OnEnable()
    {
        GameManager.Instance.gamePlayManager.typeBullet = TypeBullet.TakeDamage;
    }

    IEnumerator Spawn()
    {
        if(enemyBossType == EnemyType.Mini)
        {
            Instantiate(effect, pos1.position, Quaternion.identity);
            Instantiate(effect, pos2.position, Quaternion.identity);

            yield return new WaitForSeconds(timeDelay);
            Instantiate(miniBoss, pos1.position, Quaternion.identity);
            Instantiate(miniBoss, pos2.position, Quaternion.identity);
        }
        if(enemyBossType == EnemyType.Boss)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            AudioController.Instance.PlaySound(AudioController.Instance.warnningBoss);
            yield return new WaitForSeconds(timeDelay);
            AudioController.Instance.PlaySound(AudioController.Instance.bossStart);
            Instantiate(bossPrefab, pos1.position, Quaternion.identity);
        }
        

    }

    private void OnDisable()
    {
        StopCoroutine(Spawn());
        GameManager.Instance.gamePlayManager.typeBullet = TypeBullet.No_TakeDamage;
    }
}
