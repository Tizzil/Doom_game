using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player = null;
    Vector3 cameraPos = new Vector3(0, 0, -10);

    void OnEnable()
    {
        Player.OnPlayerActivated += OnPlayerActivated;
        Player.OnPlayerDeactivated += OnPlayerDeactivated;
    }

    void OnDisable()
    {
        Player.OnPlayerActivated -= OnPlayerActivated;
        Player.OnPlayerDeactivated -= OnPlayerDeactivated;
    }

    void OnPlayerActivated()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnPlayerDeactivated()
    {
        player = null;
    }

	void Update ()
    {
        if (player != null)
        {
            cameraPos.x = player.transform.position.x;
            cameraPos.y = player.transform.position.y;
            transform.position = cameraPos;
        }        
	}
}
