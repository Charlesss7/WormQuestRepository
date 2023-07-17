using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public WormController worm;
    public Text endScore;
    public GameObject pauseMenu;
    public GameObject gameoverMenu;
    public GameObject winMenu;
    string activeSceneName;
    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        if(activeSceneName=="Level-1"||
        activeSceneName=="Level-2"||
        activeSceneName=="Level-3"||activeSceneName=="Endless"){
            pauseMenu.SetActive(false);
            gameoverMenu.SetActive(false);
            winMenu.SetActive(false);
        }

        scene = SceneManager.GetActiveScene();
        activeSceneName = scene.name;
    }

    // Update is called once per frame
    void Update()
    {
        if(activeSceneName=="Level-1"||
        activeSceneName=="Level-2"||
        activeSceneName=="Level-3"||activeSceneName=="Endless"){
            if(Input.GetKey(KeyCode.X)){
                PauseScene();
            }
            if(Input.GetKey(KeyCode.Escape)){
                ResumeGame();
            }

            if(GameObject.FindGameObjectsWithTag("Worm").Length==0){
                GameOver();
            }
            if(GameObject.FindGameObjectsWithTag("Food").Length==0){
                Victory();
            }
        }
    }

    public void SceneLoad(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    public void Quit(){
        Application.Quit();
    }

    public void PauseScene(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GameOver(){
        gameoverMenu.SetActive(true);
        endScore.text=string.Format("Score : {0}",worm.score);
        Time.timeScale = 0f;
    }

    public void Victory(){
        winMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
