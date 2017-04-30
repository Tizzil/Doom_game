using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

    public float timing;
    public bool isPaused;
    public GameObject menu;
    public GameObject opt;
    public GameObject game;
    //public GameObject player;

    void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == true)
            {
                isPaused = false;
                game.SetActive(true);
                opt.SetActive(false);
                menu.SetActive(false);
                //player.SetActive(false);
            }
            else
            {
                isPaused = true;
                game.SetActive(false);
                opt.SetActive(false);
                menu.SetActive(true);
                //player.SetActive(true);
            }
        }

        if(isPaused == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

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
