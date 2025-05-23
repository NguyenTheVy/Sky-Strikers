﻿using Game_Fly;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : BaseAir
{
    public Transform firePos_1;
    public Transform firePos_2;
    public Transform firePos_3;
    public Transform firePos_4;
    public Transform firePos_5;

    public GameObject Sheild;


    [SerializeField] GameObject bulletPrefab;

    public float timeBtwFire = 0.2f;

    float _timeBtwFire;

    private void OnEnable ()
    {
        InitPlayer();
    }

    private void InitPlayer()
    {
        GameManager.Instance.gamePlayManager.Air = this;
    }

    protected override void FireBullet()
    {
        if (!GameManager.Instance.isStartGame) return;
        if (GameManager.Instance.gamePlayManager.isWin) return;
        _timeBtwFire -= Time.deltaTime;
        if (_timeBtwFire < 0)
        {
            _timeBtwFire = timeBtwFire;
            SimplePool.Spawn(bulletPrefab.gameObject, firePos_1.position, Quaternion.identity);

            if (firePos_2.gameObject.activeInHierarchy)
                SimplePool.Spawn(bulletPrefab.gameObject, firePos_2.position, Quaternion.identity);
            if (firePos_3.gameObject.activeInHierarchy)
                SimplePool.Spawn(bulletPrefab.gameObject, firePos_3.position, Quaternion.identity);
            if (firePos_4.gameObject.activeInHierarchy)
                SimplePool.Spawn(bulletPrefab.gameObject, firePos_4.position, Quaternion.identity);
            if (firePos_5.gameObject.activeInHierarchy)
                SimplePool.Spawn(bulletPrefab.gameObject, firePos_5.position, Quaternion.identity);
            AudioController.Instance.PlaySound(AudioController.Instance.shoot);
        }

    }




}
