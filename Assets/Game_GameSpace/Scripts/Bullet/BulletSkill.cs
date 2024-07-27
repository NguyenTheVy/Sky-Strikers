using Game_Fly;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSkill : BaseBullet
{
    [SerializeField]
    protected GameObject effect;
    private void Update()
    {
        MoveBullet();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagConst.LIMIT_2))
        {
            this.Limit();
        }
        if (GameManager.Instance.gamePlayManager.typeBullet == TypeBullet.No_TakeDamage) return;
        if (collision.CompareTag(TagConst.ENEMY))
        {
            this.Send(collision.transform);
            this.SpawnEffect();


        }

    }
    protected virtual void Limit()
    {
        Destroy(gameObject);

    }
    protected virtual void SpawnEffect()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        
    }
    protected override void MoveBullet()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

    }
}
