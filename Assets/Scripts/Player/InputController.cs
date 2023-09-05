using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(PlayerController))]
public class InputController : MonoBehaviour
{
    public static bool isReadyToMove { private get; set; }
    private float playerOffsetSpeedPC;
    private float playerOffsetSpeedAndroid;
    private float playerForwardSpeed;
    private float borderSize = 2f;
    private bool isDragging = false;
    private Vector3 lastMousePosition;
    private Vector2 touchStartPos;
    private bool isAndroidPlatform = false;

    private void Awake()
    {
        playerOffsetSpeedPC = GameSettings.Instance.GetPlayerOffsetSpeedPC();
        playerOffsetSpeedAndroid = GameSettings.Instance.GetPlayerOffsetSpeedAndroid();
        playerForwardSpeed = GameSettings.Instance.GetPlayerForwardSpeed();
        isReadyToMove = false;
        CheckPlatform();
    }

    void Update()
    {
        if (isAndroidPlatform)
        {
            InputAndroid();
        }
        else
        {
            InputPC();
        }
        if (isReadyToMove)
        {
            PlayerMoveForward();
        }
    }

    private void InputPC()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            lastMousePosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
        if (isDragging)
        {
            Vector3 mouseDelta = Input.mousePosition - lastMousePosition;
            float xOffset = mouseDelta.x * playerOffsetSpeedPC * Time.deltaTime;
            Vector3 newPosition = transform.position + new Vector3(xOffset, 0, 0);
            newPosition.x = Mathf.Clamp(newPosition.x, -borderSize, borderSize);
            transform.position = newPosition;
            lastMousePosition = Input.mousePosition;
        }
    }

    private void InputAndroid()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 touchDelta = touch.position - touchStartPos;
                float xOffset = touchDelta.x * playerOffsetSpeedAndroid * Time.deltaTime;
                Vector3 newPosition = transform.position + new Vector3(xOffset, 0, 0);
                newPosition.x = Mathf.Clamp(newPosition.x, -borderSize, borderSize);
                transform.position = newPosition;
                touchStartPos = touch.position;
            }
        }
    }

    private void PlayerMoveForward()
    {
        Vector3 forwardMovement = Vector3.forward * playerForwardSpeed * Time.deltaTime;
        transform.Translate(forwardMovement);
    }

    private void CheckPlatform()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            isAndroidPlatform = true;
        }
        else
        {
            isAndroidPlatform = false;
        }
    }
}
