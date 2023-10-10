using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private bool pause = false;
    public GameObject panel;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!pause)
            {
                Time.timeScale = 0;
                pause = true;
                panel.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                pause = false;
                panel.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
