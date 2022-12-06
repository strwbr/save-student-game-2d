using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour
{
    private void Start()
    {
        //gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void StartHandler()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ExitHandler()
    {
        SceneManager.LoadScene(0); // загрузка сцены 0 (Main Menu)
    }
}


