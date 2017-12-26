using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

}
