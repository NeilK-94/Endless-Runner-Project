using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{ 
    public string startGameLevel;

    public void StartGame() //  tell app to load up endless runner scene
    {
        Application.LoadLevel(startGameLevel);
    }

    public void QuitGame()  //  quit app
    {
        Application.Quit();

    }

}
