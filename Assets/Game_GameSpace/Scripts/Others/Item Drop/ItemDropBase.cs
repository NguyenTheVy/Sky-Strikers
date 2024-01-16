using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game_Fly;
public class ItemDropBase : MonoBehaviour
{
    public float moveDistance = 20f; // Khoảng cách di chuyển
    public float moveDuration = 5f; // Thời gian di chuyển
    protected virtual void Start()
    {
        MoveItem();

    }

    protected virtual void MoveItem()
    {
        /*transform.Translate(Vector2.down * speed * Time.deltaTime);*/
        // Sử dụng DOMove để di chuyển từ bên trên xuống
        transform.DOMoveY(transform.position.y - moveDistance, moveDuration)
                .SetEase(Ease.Linear);


    }

    
}
