using Game_Fly;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAir : MonoBehaviour
{
    Vector2 difference = Vector2.zero;
    

    private Camera mainCamera;
    private float minX, maxX, minY, maxY;
    private float playerHalfWidth, playerHalfHeight;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    private int activeTouchId = -1;


    private void OnMouseDown()
    {
        if (GameManager.Instance.gamePlayManager.isWin) return;
        difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
    }

    private void OnMouseDrag()
    {
        if (GameManager.Instance.gamePlayManager.isWin) return;
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
    }
    private void HandleTouch()
    {
        if (GameManager.Instance.gamePlayManager.isWin) return;
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        Vector2 touchPosition = mainCamera.ScreenToWorldPoint(touch.position);
                        if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPosition))
                        {
                            activeTouchId = touch.fingerId;
                            difference = touchPosition - (Vector2)transform.position;
                        }
                        break;

                    case TouchPhase.Moved:
                        if (touch.fingerId == activeTouchId)
                        {
                            Vector2 newPosition = (Vector2)mainCamera.ScreenToWorldPoint(touch.position) - difference;
                            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
                        }
                        break;

                    case TouchPhase.Ended:
                    case TouchPhase.Canceled:
                        if (touch.fingerId == activeTouchId)
                        {
                            activeTouchId = -1;
                        }
                        break;
                }
            }
        }
    }




    private void Start()
    {

        
        mainCamera = Camera.main;
        // Lấy kích thước của người chơi (Player)
        SpriteRenderer playerRenderer = GetComponent<SpriteRenderer>();
        playerHalfWidth = playerRenderer.bounds.size.x / 2f;
        playerHalfHeight = playerRenderer.bounds.size.y / 2f;

        // Tính toán giới hạn dựa trên Camera
        CalculateCameraBounds();
    }

    
    
    private void Update()
    {
        CheckLimitCam();
        FireBullet();
        
    }

    private void FixedUpdate()
    {

    }


    void CalculateCameraBounds()
    {
        if (mainCamera != null)
        {
            float cameraOrthographicSize = mainCamera.orthographicSize;
            float aspectRatio = Screen.width / (float)Screen.height;

            // Tính toán giới hạn dựa trên Camera
            minX = mainCamera.transform.position.x - cameraOrthographicSize * aspectRatio;
            maxX = mainCamera.transform.position.x + cameraOrthographicSize * aspectRatio;
            minY = mainCamera.transform.position.y - cameraOrthographicSize;
            maxY = mainCamera.transform.position.y + cameraOrthographicSize;
        }
    }

    void CheckLimitCam()
    {

        //HandleTouch();
        // Lấy vị trí hiện tại của người chơi
        Vector3 currentPosition = transform.position;

        // Giới hạn vị trí trên trục X
        currentPosition.x = Mathf.Clamp(currentPosition.x, minX + playerHalfWidth, maxX - playerHalfWidth);

        // Giới hạn vị trí trên trục Y
        currentPosition.y = Mathf.Clamp(currentPosition.y, minY + playerHalfHeight, maxY - playerHalfHeight);

        // Cập nhật vị trí của người chơi
        transform.position = currentPosition;

        // Xử lý di chuyển của người chơi
        // Đảm bảo bạn có mã xử lý di chuyển ở đây, ví dụ: Input.GetKey, Input.GetAxis, ...
    }
    protected virtual void FireBullet()
    {

    }
}
