using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer;

    public Text timerNum;
    public WormController worm;
    public GameObject gameoverMenu;
    public Text endScore;
    void Start(){
        Time.timeScale = 1f;
        if(worm.enabled==true){
            StartCoroutine("countDown");
        }
    }

    void Update(){
        if(worm.enabled==true){
            if(timer>0){
                timer -= Time.deltaTime;
            }
            else{
                timer =0;
            }
        }
        DisplayCountDown(timer);

        if(timer==0){
            GameOver();
        }
    }

    private IEnumerator countDown(){
        yield return new WaitForSeconds(timer);

        // worm.SetActive(true);
        // control.enabled=!control.enabled;
        StopCoroutine("countDown");
    }

    void DisplayCountDown(float timeToDisplay){
        if(timeToDisplay<0){
            timeToDisplay=0;
            timerNum.gameObject.SetActive(false);
        }
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        
        timerNum.text= string.Format("{0}",seconds);
    }

    public void GameOver(){
        gameoverMenu.SetActive(true);
        endScore.text=string.Format("Score : {0}",worm.score);
        Time.timeScale = 0f;
    }
}
