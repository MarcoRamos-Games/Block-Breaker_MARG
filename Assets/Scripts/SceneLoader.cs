using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
  
  public void LoadNextScene ()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //Create a variable that is equal to the scene number we are currently at
        SceneManager.LoadScene(currentSceneIndex + 1 ); //Loads the next scen by adding 1 to the previous variable
    }
    public void LoadStartScene()
    {
        FindObjectOfType<GameSession>().ResetGame(); //Calls the game session scrpit and use the method Reset Game
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();  //Close the application
    }
}
