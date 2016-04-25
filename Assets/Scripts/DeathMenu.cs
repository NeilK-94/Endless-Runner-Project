using UnityEngine;
using System.Collections;

public class DeathMenu : MonoBehaviour {

    public string mainMenuLevel;

    public void RestartGame()
    {
        FindObjectOfType<GameManager>().Reset();    //  fin the object in the scene attached to game manager
    }

    public void QuitToMenu()
    {
        Application.LoadLevel(mainMenuLevel);
    }
}
