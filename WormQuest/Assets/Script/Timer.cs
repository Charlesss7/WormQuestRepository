using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer;

    public Text timerNum;
    public WormController worm;
    void Start(){
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
}
