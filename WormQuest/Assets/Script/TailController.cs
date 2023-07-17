using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailController : MonoBehaviour
{
    public Transform Tail;
    public float capsuleDiameter;

    private List<Transform> tail = new List<Transform>();
    private List<Vector2> positions = new List<Vector2>();
    // Start is called before the first frame update
    void Start()
    {
        positions.Add(Tail.position);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = ((Vector2)Tail.position - positions[0]).magnitude;

        if(distance > capsuleDiameter){
            Vector2 direction = ((Vector2)Tail.position-positions[0]).normalized;

            positions.Insert(0,positions[0] + direction * capsuleDiameter /2);
            positions.RemoveAt(positions.Count - 1);

            distance -= capsuleDiameter;
        }

        for(int i =0; i <tail.Count;i++){
            tail[i].position = Vector2.Lerp(positions[i+1],positions[i],(distance/capsuleDiameter)*2);
        }
    }

    public void AddTail(){
        Transform tails = Instantiate(Tail, positions[positions.Count-1],Quaternion.identity,transform);
        tail.Add(tails);
        positions.Add(tails.position);
        Debug.Log("add tail");
    }
}
