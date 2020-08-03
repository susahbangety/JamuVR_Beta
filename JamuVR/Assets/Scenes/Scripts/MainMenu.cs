using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionMenu;

    public void PlayButton()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void OptionButton()
    {
        //optionMenu.SetActive(true);
        Debug.Log("Option");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
