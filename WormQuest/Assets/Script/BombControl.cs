using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombControl : MonoBehaviour
{
    public float bombSpawnTime;
    public GameObject bombPrefab;
    public CircleCollider2D colliders;
    public SpriteRenderer sprites;
    void FixedUpdate(){
        StartCoroutine("spawnBomb");
    }

    private IEnumerator spawnBomb(){
        yield return new WaitForSeconds(bombSpawnTime);

        if(colliders.enabled==true){
            colliders.enabled=!colliders.enabled;
            sprites.enabled=!sprites.enabled;
        }
        else{
            colliders.enabled=!colliders.enabled;
            sprites.enabled=!sprites.enabled;
        }

        StopCoroutine("spawnBomb");
    }
}
