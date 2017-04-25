using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject player;
    public Transform shotSpawn;
    public GameObject bullet;
    public float speed;
    public float fireRate = 0.5f;
    float timer;

    private void Update()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float mouselistener = Input.GetAxis("Fire1");
        timer += Time.time;

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveHorizontal,moveVertical)*speed;
        if (Input.GetButton("Fire1") && timer > fireRate)
        {
            timer = 0;
            Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
        }
        


    }
    

}
