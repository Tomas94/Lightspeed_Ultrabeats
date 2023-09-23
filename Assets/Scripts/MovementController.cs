using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementController : MonoBehaviour
{
    Vector2 dragDirection;
    [SerializeField] Vector2 screenBounds;
    [SerializeField] float playerWidth;
    [SerializeField] float playerHeight;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        playerWidth = transform.GetComponent<BoxCollider>().size.x * 0.5f;
        playerHeight = transform.GetComponent<BoxCollider>().size.y * 0.5f;
        
    }

    private void Update()
    {
        if (Input.touchCount < 1) return;

        Touch firstTouch = Input.touches[0];

        if (firstTouch.phase == TouchPhase.Moved)
        {
            dragDirection = firstTouch.deltaPosition ;

            transform.position += ((Vector3)dragDirection * Time.deltaTime);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, (screenBounds.x * -1 + playerWidth), screenBounds.x - playerWidth), Mathf.Clamp(transform.position.y, (screenBounds.y * -1 + playerHeight), screenBounds.y - playerHeight), 0);
            
        }
    }



}
