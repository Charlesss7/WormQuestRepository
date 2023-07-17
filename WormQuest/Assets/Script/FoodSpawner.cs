using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public float foodSpawnTime;
    public GameObject foodPrefab;
    public int spawnRange;

    void FixedUpdate(){
        StartCoroutine("spawnFood");
    }

    private IEnumerator spawnFood(){
        yield return new WaitForSeconds(foodSpawnTime);

        Vector2 RandomPos = new Vector2(Random.Range(transform.position.x - spawnRange,transform.position.x + spawnRange), Random.Range(transform.position.y - spawnRange, transform.position.y + spawnRange));

        Instantiate(foodPrefab, RandomPos, Quaternion.identity);

        StopCoroutine("spawnFood");
    }
}
