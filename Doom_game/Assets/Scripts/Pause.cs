using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

    public float timing;
    public bool isPaused;
    public GameObject menu;
    public GameObject opt;
    public GameObject game;

    void Update () {
	    if(Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            isPaused = true;
            game.SetActive(false);
            opt.SetActive(false);
            menu.SetActive(true);

        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            isPaused = false;
            game.SetActive(true);
            opt.SetActive(false);
            menu.SetActive(false);
        }

        if(isPaused == true)
        {
            Time.timeScale = 0;
        }
        else if(isPaused == false)
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
