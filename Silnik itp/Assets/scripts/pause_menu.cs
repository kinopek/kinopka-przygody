using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause_menu : MonoBehaviour {

    public GameObject pause_ui;

    private bool paused = false;

    void Start() {

        pause_ui.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }

        if (paused)
        {
            pause_ui.SetActive(true);
            Time.timeScale = 0;
        }

        if (!paused)
        {
            pause_ui.SetActive(false);
            Time.timeScale = 1;
        }

    }

    public void Resume()
    {
        paused = false;
    }

	public void Restart(){

		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);

	}

	public void Main_menu(){

		SceneManager.LoadScene (SceneManager.GetSceneAt(0).buildIndex); // No main menu, change the number at a later date

	}

	public void Quit(){

		Application.Quit ();
	}
}
