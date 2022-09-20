using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "MainPlayer") {
            SceneManager.LoadScene("Scenes/Level2");
        }
    }
    // Start is called before the first frame update
    // public void PlayGame() {
    //     SceneManager.LoadScene("Scenes/Level1");
    // }

    // public void AboutGame() {
    //     SceneManager.LoadScene("Scenes/About");
    // }

    // public void Quit() {
    //     Debug.Log("We are quit!!!");
    //     Application.Quit(); //работает только, когда есть "билд"
    // }
}
