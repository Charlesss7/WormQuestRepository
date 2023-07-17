using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject worm;
    public WormController control;
    public float countDownTime;
    public Text countDownNum;
    public Text scoreNum;

    string activeSceneName;
    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("countDown");

        scene = SceneManager.GetActiveScene();
        activeSceneName = scene.name;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(GameObject.FindGameObjectsWithTag("Food").Length == 0){
            Debug.Log("Game Done");
        }

        if(countDownTime>0){
            countDownTime -= Time.deltaTime;
        }
        else{
            countDownTime =0;
        }

        if(activeSceneName=="Endless"){
            DisplayScore(control.score);
        }

            DisplayCountDown(countDownTime);
    }

    private IEnumerator countDown(){
        yield return new WaitForSeconds(countDownTime);

        // worm.SetActive(true);
        control.enabled=!control.enabled;
        Debug.Log("Game Started");
        StopCoroutine("countDown");
    }

    void DisplayCountDown(float timeToDisplay){
        if(timeToDisplay<0){
            timeToDisplay=0;
            countDownNum.gameObject.SetActive(false);
        }
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        
        countDownNum.text= string.Format("{0}",seconds);
    }

    void DisplayScore(float score){
        scoreNum.text=string.Format("{0}",score);
    }
}
