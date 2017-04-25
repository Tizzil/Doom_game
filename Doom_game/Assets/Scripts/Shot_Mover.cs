using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Mover : MonoBehaviour {
    float mouseX;
    float mouseY;
    public float speed;
    public Transform bullet;
    bool a = false;

	void Start () {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
    }
	
	void Update () {
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(speed,0);
    }
}
