using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementController : MonoBehaviour
{
    public  float speed;
    Vector2 _dragDirection;
    [SerializeField] Vector2 _screenBounds;
    public bool _keyboardInputs;

    private void Update()
    {
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        // _playerWidth = transform.GetComponent<BoxCollider>().size.x * 0.5f;
        // _playerHeight = transform.GetComponent<BoxCollider>().size.y * 0.5f;
        if (_keyboardInputs)
        {
            KeyboardInput();
        }
        else
        {
            MobileInputs();
        }
        
    }

    void KeyboardInput()
    {
        Vector3 dir = new Vector3();
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        transform.position += dir * speed * Time.deltaTime;
    }

    void MobileInputs()
    {
        if (Input.touchCount < 1) return;

        Touch firstTouch = Input.touches[0];

        if (firstTouch.phase == TouchPhase.Moved)
        {
            _dragDirection = firstTouch.deltaPosition;

            transform.position += ((Vector3)_dragDirection * Time.deltaTime);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, (_screenBounds.x * -1), _screenBounds.x), Mathf.Clamp(transform.position.y, (_screenBounds.y * -1), _screenBounds.y), 0);
        }
    }

}
