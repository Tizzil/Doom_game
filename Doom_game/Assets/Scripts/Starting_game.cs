using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starting_game : MonoBehaviour {

    public GameObject camera_obj;
    public GameObject clickable;
    bool a = true;

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButton("Fire1") == true && (a == true)))
        {
            camera_obj.transform.position.Set(0, 500, -40);
            camera_obj.transform.rotation.Set(90, 0, 0, 0);
            a = false;
        }
    }
}
