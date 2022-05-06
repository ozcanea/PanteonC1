using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    int obstaclesCounter, typeOfObstacles;//0 static 1 moving obstacle
    [SerializeField] int maxObstacle;
    float distance;//distace between every obstacles
    float minDistance = 2.7f;
    float maxDistance = 4f;
    [SerializeField] GameObject staticObstacle;
    [SerializeField] GameObject horizontalObstacle;
    Vector3 previousObjectPos;

    private void Awake()
    {
        int i = 0;
        while (i<maxObstacle)
        {
            CreateNewObstacle();
            i++;
        }
        
    }

    void CreateStaticObstacle()
    {
        distance = Random.Range(minDistance, maxDistance);
        Vector3 instantiatePos = new Vector3();
        instantiatePos.z = previousObjectPos.z + distance;
        float locationAtXAxis = Random.Range(-1.83f, 1.83f);
        instantiatePos.x = locationAtXAxis;
        instantiatePos.y = staticObstacle.transform.position.y;
        Instantiate(staticObstacle, instantiatePos, Quaternion.identity);
        previousObjectPos = instantiatePos;
        obstaclesCounter++;
    }
    void CreateStaticObstacle(float firstPosAtZ)
    {

        Vector3 instantiatePos = new Vector3();
        instantiatePos.z = firstPosAtZ;
        float locationAtXAxis = Random.Range(-1.83f, 1.83f);
        instantiatePos.x = locationAtXAxis;
        instantiatePos.y = staticObstacle.transform.position.y;
        Instantiate(staticObstacle, instantiatePos, Quaternion.identity);
        previousObjectPos = instantiatePos;
        obstaclesCounter++;
    } // for first Obstacle

    void CreateHorizontalObstacle()
    {
        distance = Random.Range(minDistance, maxDistance);
        Vector3 instantiatePos = new Vector3();
        instantiatePos.z = previousObjectPos.z + distance;
        bool isRight = Random.Range(0, 2) == 0 ? false : true;
        if (isRight)
        {
            instantiatePos.x = 2f;
        }
        if (!isRight)
        {
            instantiatePos.x = -2f;
        }
        instantiatePos.y = horizontalObstacle.transform.position.y;
        GameObject newObstacle = Instantiate(horizontalObstacle, instantiatePos, Quaternion.identity);
        previousObjectPos = newObstacle.transform.position;
        obstaclesCounter++;
    }
    void CreateNewObstacle()
    {
        if (obstaclesCounter == maxObstacle) return;
        typeOfObstacles = Random.Range(0, 2);//2 is exclusive

        if (obstaclesCounter==0)
        {
            CreateStaticObstacle(5f);
        }
        else
        {
            if (typeOfObstacles == 0)
            {
                CreateStaticObstacle();
            }
            if (typeOfObstacles == 1)
            {
                CreateHorizontalObstacle();

            }
        }
    }
}

