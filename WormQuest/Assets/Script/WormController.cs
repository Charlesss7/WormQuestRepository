using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormController : MonoBehaviour
{
    public float rotationSensitivity;
    private float speed;
    public float normalSpeed;
    public float boostSpeed;
    public float score=0;
    private Vector3 mousePos;

    public GameObject bodyPrefab;
    private float bodyFollowSpeed;
    public float normalFollowSpeed;
    public float boostFollowSpeed;

    public float sensitivityGrowing;
    public AudioSource foodSFX;
    public AudioSource deathSFX;
    private float currentSize = 1;
    private List<Transform> BodyParts = new List<Transform>();

    void Start(){
        speed = normalSpeed;
        bodyFollowSpeed = normalFollowSpeed;
    }
    private void FixedUpdate(){
        RotateToMouse();
        Movement();
        BoostMovement();
        BodyMovement();

        //code snippet for testing add bodypart
        // if(Input.GetKey(KeyCode.F)){
        //     Debug.Log("added");
        //     AddBodyParts();
        // }
    }

    private void RotateToMouse(){
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Quaternion direction = Quaternion.LookRotation(Vector3.forward, mousePos-transform.position);

        transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotationSensitivity * Time.deltaTime);

    }

    private void Movement(){
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private bool Boost;
    void BoostMovement(){
        if(Boost != false){
            if(Input.GetMouseButton(0)){
                speed = normalSpeed;
                boostFollowSpeed = normalFollowSpeed;
                Boost = false;
            }
        }
        else{
            if(Input.GetMouseButton(0)){
                speed = boostSpeed;
                bodyFollowSpeed = boostFollowSpeed;
                Boost = true;
            }
        }
    }

    void BodyMovement(){
        for(int i =0; i<BodyParts.Count;i++){
            if(i != 0){
                BodyParts[i].position = Vector3.Lerp(BodyParts[i].position, BodyParts[i-1].position, bodyFollowSpeed);
                BodyParts[i].up = BodyParts[i].position - BodyParts[i-1].position;
            }
            else{
                BodyParts[i].position = Vector3.Lerp(BodyParts[i].position, transform.position, bodyFollowSpeed);
                BodyParts[i].up = BodyParts[i].position - transform.position;
            }
        }
    }

    void AddBodyParts(){
        if(BodyParts.Count != 0){
            GameObject newBody = Instantiate(bodyPrefab, BodyParts[BodyParts.Count-1].position, BodyParts[BodyParts.Count-1].rotation);
            newBody.transform.localScale = transform.localScale/2;
            newBody.GetComponent<SpriteRenderer>().sortingOrder = (0 - 1 - BodyParts.Count);

            BodyParts.Add(newBody.transform);
        }

        else{
            GameObject newBody = Instantiate(bodyPrefab, transform.position, transform.rotation);
            newBody.transform.localScale = transform.localScale/2;
            newBody.GetComponent<SpriteRenderer>().sortingOrder = (0 - 1 - BodyParts.Count);

            BodyParts.Add(newBody.transform);
        }
        Growing();
    }

    void Growing(){
        currentSize += sensitivityGrowing;
        transform.localScale = Vector3.one * currentSize;

        normalFollowSpeed = (normalSpeed / 15) / currentSize;
        boostFollowSpeed = (boostSpeed / (15 + boostSpeed - normalSpeed) / currentSize);
        if(Boost != true){
            speed = normalSpeed;
        }
        else{
            speed = boostSpeed;
        }

        foreach(Transform body in BodyParts){
            body.localScale = transform.localScale;
        }

        if(rotationSensitivity > 0.5f){
            rotationSensitivity -= 0.01f;
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Food"){
            Destroy(other.gameObject);
            
            AddBodyParts();
            score++;
            foodSFX.Play();
        }

        if(other.gameObject.tag == "Obstacle"){
            Destroy(this.gameObject);
            deathSFX.Play();
        }
    }
}
