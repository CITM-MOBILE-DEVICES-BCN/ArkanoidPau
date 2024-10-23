using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
                GameManager.instance.isPaused = false;
            }
            else
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                GameManager.instance.isPaused = true;
            }
        }
    }
}
