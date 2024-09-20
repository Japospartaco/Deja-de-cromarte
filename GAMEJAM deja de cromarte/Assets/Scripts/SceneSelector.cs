using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSelector : MonoBehaviour
{
    public void End()
    {
        SceneManager.LoadScene("End");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void Jugar()
    {
        SceneManager.LoadScene("Level");
    }

    public void Uso()
	{
        SceneManager.LoadScene("Use");
	}

    public void Opciones()
	{
        SceneManager.LoadScene("Options");
	}
}
