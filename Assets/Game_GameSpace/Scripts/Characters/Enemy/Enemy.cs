using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseEnemy
{
    public Transform firePos;
    public GameObject bulletPrefab;
    //public float timeBtwFire;
    public Transform holderPrefabs;
    
    public float minShootInterval = 1f;
    public float maxShootInterval = 3f;

    private float timeToShoot;
    private float nextShootTime;

    

    void Start()
    {
        // Khởi tạo thời gian bắn ngẫu nhiên ban đầu
        SetNextShootTime();
    }

    
    protected override void FireBullet()
    {
        
       
        if (Time.time > timeToShoot)
        {
      
            anim.SetBool("Shooting", true);
            SetNextShootTime();
            
            SimplePool.Spawn(bulletPrefab, firePos.position, Quaternion.identity);
           
        }
    }

    void SetNextShootTime()
    {
        // Thiết lập thời gian bắn ngẫu nhiên trong khoảng min và max
        nextShootTime = Random.Range(minShootInterval, maxShootInterval);
        timeToShoot = Time.time + nextShootTime;
    }


    public void EndShootingEvent()
    {
        anim.SetBool("Shooting", false);
    }





}
