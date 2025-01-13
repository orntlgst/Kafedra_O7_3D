using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuClass : MonoBehaviour
{
    public static bool IsPaused = false;
    public static bool MapUp = false;

    public GameObject PauseMenu;
    public GameObject MapMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if ((IsPaused) && (!MapUp))
            {
                Resume();
            }
            else if (!MapUp)
            {
                Pause();
            }
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (MapUp)
            {
                MapDown();
            }
            else
            {
                ShowMap();
            }
        }
    }

    public void MapDown()
    {
        MapMenu.SetActive(false);
        Time.timeScale = 1f;
        MapUp = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ShowMap()
    {
        MapMenu.SetActive(true);
        Time.timeScale = 0f;
        MapUp = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
