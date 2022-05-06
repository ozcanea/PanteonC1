using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingObkectForCamera : MonoBehaviour
{

    Player player;
    float fObjectSpeed;// following object speed
    private void Start()
    {
        
        player = FindObjectOfType<Player>();
        fObjectSpeed = player.moveSpeed;

    }

    private void Update()
    {
        Follow();
    }

    void Follow()
    {

        Vector3 targetPos= transform.localPosition;
        targetPos.z=player.transform.localPosition.z+1;
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, fObjectSpeed * Time.deltaTime);

    }
}
