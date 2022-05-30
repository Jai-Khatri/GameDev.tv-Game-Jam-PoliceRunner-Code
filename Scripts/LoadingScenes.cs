using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadingScenes : MonoBehaviour
{
    
    public void LoadGame()
    {
        SceneManager.LoadScene(1); // Loads The game
    }


    public void Quitgame()
    {
        Application.Quit(); //Quits the game.
    }
}

