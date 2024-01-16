using Game_Fly;
using System.Collections;
using System.Collections.Generic;
using TigerForge;
using UnityEngine;

public class BulletPlayer : BaseBullet
{
    [SerializeField]
    protected GameObject effect;

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
            
            this.DestroyBullet();
        }
        
    }



    protected virtual void DestroyBullet()
    {
        Instantiate(effect, transform.position, Quaternion.identity);

        SimplePool.Despawn(gameObject);
    }

    protected virtual void Limit()
    {
        SimplePool.Despawn(gameObject);

    }

    

    private void Update()
    {
        MoveBullet();
    }

    protected override void MoveBullet()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

    }


}
