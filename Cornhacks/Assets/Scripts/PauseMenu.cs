using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;

    public GameObject menu;

    public Player player;

    void Start() {
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (paused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume() {
        paused = false;
        menu.SetActive(false);
        player.menu = false;
    }

    void Pause() {
        paused = true;
        menu.SetActive(true);
        player.menu = true;
    }

    public void Quit() {
        Debug.Log("Qutting");
        Application.Quit();
    }
}
