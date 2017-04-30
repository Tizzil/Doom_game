using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bord
{
    public float xMin, xMax, yMin, yMax;
}

public class Border : MonoBehaviour {
    public GameObject player;
    public Bord border;

    void Update() {
        player.GetComponent<Rigidbody2D>().position = new Vector3(
            Mathf.Clamp(player.GetComponent<Rigidbody2D>().position.x, border.xMin, border.xMax),
            Mathf.Clamp(player.GetComponent<Rigidbody2D>().position.y, border.yMin, border.yMax),
            0f
        );
	}
}
