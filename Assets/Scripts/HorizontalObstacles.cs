using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HorizontalObstacles : MonoBehaviour
{
    Vector3 right;
    Vector3 left;
    Vector3 nextPos;
    int speed;


    private void Start()
    {
        speed = Random.Range(2, 5);
        left = transform.position;
        left.x = -2f;
        right = transform.position;
        right.x = 2f;
        nextPos = transform.position;
        nextPos.x *= -1;
    }
    void Update()
    {
        if (transform.position == right)
        {
            nextPos = left;
        }
        else if (transform.position == left)
        {
            nextPos = right;
        }
        MoveObstacle(nextPos);
    }
    void MoveObstacle(Vector3 targetVector)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetVector, speed * Time.deltaTime);

    }

}
