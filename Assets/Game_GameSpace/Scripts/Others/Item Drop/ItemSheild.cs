using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game_Fly;
public class ItemSheild : ItemDropBase
{
    [SerializeField] GameObject shield;

    

    private void OnEnable()
    {
        initSheild();
    }

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindWithTag("PlayerItem"); // Giả sử máy bay có tag "Player"
        if (player != null)
        {
            // Gắn Shield vào Player
            transform.SetParent(player.transform);
            transform.localPosition = Vector3.zero;
            StartCoroutine(RemoveShieldAfterDuration());
        }
    }

    private void initSheild()
    {
        shield = GameManager.Instance.gamePlayManager.Air.Sheild;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagConst.PLAYER))
        {
            shield.SetActive(true);
            AudioController.Instance.PlaySound(AudioController.Instance.getItem);
            gameObject.SetActive(false);
        }
    }
    public float shieldDuration = 5.0f; // Thời gian shield tồn tại
    private GameObject player;

    

    private IEnumerator RemoveShieldAfterDuration()
    {
        yield return new WaitForSeconds(shieldDuration);
        Destroy(gameObject); // Hủy shield sau khi hết thời gian
    }

    void OnTriggerEnter(Collider other)
    {
        // Giả sử kẻ thù hoặc đạn có tag "Enemy" hoặc "Bullet"
        if (other.CompareTag(TagConst.BULLET) || other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); // Hủy đối tượng va chạm
            // Bạn có thể thêm hiệu ứng phá hủy ở đây
        }
    }
}
