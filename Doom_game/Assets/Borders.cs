using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour {
    public Collider border;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        OnTriggerEnter(border);
	}
    
    private void OnTriggerEnter(Collider collision)
    {
        
    }
    /*
    public void OnCollisionEnter(Collision collision)
    {
        
    }*/
}
