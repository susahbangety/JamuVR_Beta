using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButton()
    {
        Debug.Log("Play");
        //SceneManager.LoadScene("Gameplay");
    }

    public void OptionButton()
    {
        Debug.Log("Option");
    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}
