using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPanelController : MonoBehaviour
{
    public RectTransform recTransform;

    private Vector2 offScreenPosition;
    private Vector2 onScreenPosition;
    [Range(0.1f, 3.0f)]
    private float speed = 1.0f;
    private float timer = 0.0f;
    public bool isOnScreen = false;

    public CameraController playerCam;
    // Start is called before the first frame update
    void Start()
    {
        playerCam = FindObjectOfType<CameraController>();
        recTransform = GetComponent<RectTransform>();
        recTransform.anchoredPosition = new Vector2(250.0f, -200.0f);
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Cursor.lockState = CursorLockMode.None;
            isOnScreen = !isOnScreen;
            playerCam.enabled = isOnScreen;
            timer = 0.0f;
        }

        if (isOnScreen)
        {
            MoveControlPanelDown();
        }
        else
        {
            MoveControlPanelUp();
        }
    }

    private void MoveControlPanelDown()
    {
        Vector2.Lerp(offScreenPosition, onScreenPosition, timer);
        if (timer < 1.0f)
        {
            timer += Time.deltaTime * speed;
        }
    }

    private void MoveControlPanelUp()
    {

    }
}
