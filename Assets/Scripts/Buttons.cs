using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject menu;
    
    public void Button_Resume()
    {
        Time.timeScale = 1; // Velocidad del juego. A 0 lo pausamos!
        menu.SetActive(false);
    }
    public void Button_Exit()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(0);
    }
    public void Button_Play()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Button_Restart()
    {
        Time.timeScale = 1; // Velocidad del juego. A 0 lo pausamos!
        SceneManager.LoadScene(1);
    }

}
