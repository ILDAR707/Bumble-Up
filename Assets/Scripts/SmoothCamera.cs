using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Transform player;
    Vector3 distanceBetweenPlayerCamera;
    public float speed = 0.5f;

    private void Awake()
    {
        MyEventManager.eventPlayerDead += EnableFalse;
    }

    private void Start()
    {
        distanceBetweenPlayerCamera = transform.position - player.position;
    }

    private void OnDestroy()
    {
        MyEventManager.eventPlayerDead -= EnableFalse;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(
                transform.position, 
                new Vector3(0f, player.position.y, player.position.z) + distanceBetweenPlayerCamera,
                speed);
    }

    void EnableFalse()
    {
        this.enabled = false;
    }
}