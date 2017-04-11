using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

    public float timing;
    public bool isPaused;
    public GameObject menu;
    public GameObject opt;
    public GameObject game;
    //public GameObject gameplay_obj;


    private void Start()
    {
        Time.timeScale = timing;
    }

    void Update () {
	    if(Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            timing = 0;
            isPaused = true;
            game.SetActive(false);
            opt.SetActive(false);
            menu.SetActive(true);

        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            timing = 1;
            isPaused = false;
            game.SetActive(true);
            opt.SetActive(false);
            menu.SetActive(false);
        }
        /*
        if(isPaused == true)
        {
            timing = 0;
        }
        else if(isPaused == false)
        {
            timing = 1;
        }
        */
	}

    public void ResumeButton(bool state)
    {
        isPaused = state;
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
