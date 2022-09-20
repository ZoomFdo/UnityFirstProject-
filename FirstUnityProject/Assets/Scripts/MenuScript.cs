using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame() {
        SceneManager.LoadScene("Scenes/Level1");
    }

    public void LevelsGame() {
        SceneManager.LoadScene("Scenes/Levels");
    }

    public void AboutGame() {
        SceneManager.LoadScene("Scenes/About");
    }

    public void ExitLevelsGame() {
        SceneManager.LoadScene("Scenes/Menu");
    }
    public void ExitAboutGame() {
        SceneManager.LoadScene("Scenes/Menu");
    }
    public void BackToMenu() {
        SceneManager.LoadScene("Scenes/Menu");
    }

    public void Level1Game() {
        SceneManager.LoadScene("Scenes/Level1");
    }
    public void Level2Game() {
        SceneManager.LoadScene("Scenes/Level2");
    }
    public void Level3Game() {
        SceneManager.LoadScene("Scenes/Level3");
    }


    public void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            ExitGame();
        }
    }
    public void ExitGame() {
        UnityEditor.EditorApplication.isPlaying = false;
        Debug.Log("We are quit!!!");
        Application.Quit(); //работает только, когда есть "билд"
    }



    // public void Quit() {
    //     Debug.Log("We are quit!!!");
    //     Application.Quit(); //работает только, когда есть "билд"
    // }
}
