using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Mover : MonoBehaviour {
    float mouseX;
    float mouseY;
    public Transform bullet;
	// Use this for initialization
	void Start () {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
