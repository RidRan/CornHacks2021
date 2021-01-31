using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;
    bool main = true;

    public GameObject pauseMenu;
    public GameObject mainMenu;

    public Player player;

    void Start() {
        mainMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !main) {
            if (paused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume() {
        paused = false;
        pauseMenu.SetActive(false);
        player.menu = false;
    }
    
    public void PlayGame() {
        main = false;
        mainMenu.SetActive(false);
        player.menu = false;
    }

    void Pause() {
        paused = true;
        pauseMenu.SetActive(true);
        player.menu = true;
    }

    public void Quit() {
        Debug.Log("Qutting");
        Application.Quit();
    }
}
