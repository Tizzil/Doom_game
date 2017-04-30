using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Mover : MonoBehaviour {/*
    float mouseX;
    float mouseY;
    float pX, pY;
    public float speed;
    public Transform bullet;
    public Transform shotspawn;*/

    void Start () {/*
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        pX = shotspawn.GetComponent<Transform>().position.x;
        pY = shotspawn.GetComponent<Transform>().position.y;
        */
        //bullet.GetComponent<Transform>().position.Set(pX, pY, shotspawn.GetComponent<Transform>().position.z);
    }
	
	void Update () {/*
        float sX, sY;
        sX = mouseX - pX;
        sY = mouseY - pY;
        float module = Mathf.Sqrt(Mathf.Pow(sX, 2) + Mathf.Pow(sY, 2));
        sX = (sX / module);
        sY = (sY / module);
        bullet.GetComponent<Rigidbody2D>().position.Set(bullet.GetComponent<Transform>().position.x + sX, bullet.GetComponent<Transform>().position.y + sY);*/
    }
    /*
        speedX = PL_Crosshair.x - Player.x;
		speedY = PL_Crosshair.y - Player.y;
		var module = Math.sqrt( Math.pow(speedX, 2) + Math.pow(speedY, 2) );
		speedX = (speedX / module *15) ;
		speedY = (speedY / module *15) ;
		x = Player_var.x;
		y = Player_var.y;
    */
}