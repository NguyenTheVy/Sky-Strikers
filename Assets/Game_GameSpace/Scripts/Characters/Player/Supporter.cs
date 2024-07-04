using Game_Fly;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supporter : MonoBehaviour
{
    public Transform firePos_1;
    public float timeBtwFire = 0.2f;

    [SerializeField] GameObject bulletPrefab;

    float _timeBtwFire;

    private void Update()
    {
        FireBullet();
    }
    public void FireBullet()
    {
        if (!GameManager.Instance.isStartGame) return;
        _timeBtwFire -= Time.deltaTime;
        if (_timeBtwFire < 0)
        {
            _timeBtwFire = timeBtwFire;
            // GameObject bulletClone = Instantiate(bulletPrefab, firePos.position, Quaternion.identity);
            SimplePool.Spawn(bulletPrefab.gameObject, firePos_1.position, Quaternion.identity);






            //AudioController.Instance.PlaySound(AudioController.Instance.shoot);
            /*Rigidbody2D rb = bulletClone.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);*/
        }
    }
}
