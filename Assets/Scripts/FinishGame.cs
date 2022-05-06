using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    [SerializeField]Transform target;
    Player player;


    private void Start()
    {
        player = FindObjectOfType<Player>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.isFinished = true;
            Vector3 pos = other.transform.position;
            other.gameObject.GetComponent<Animator>().SetTrigger("MoveOn");
            pos.z = target.localPosition.z - 1f;
            other.gameObject.transform.position = pos;
            if (other.gameObject.transform.position == pos)
            {
                player.animator.SetTrigger("Idle");
            }
            GameObject[] opponents = GameObject.FindGameObjectsWithTag("Opponent");
            foreach (GameObject item in opponents)
            {
                Destroy(item);
            }
        }
        if (other.gameObject.tag == "Opponent")
        {
            player.isFinished=true;
            DestroyOpponents();
            player.animator.SetTrigger("Cry");

        }

        void DestroyOpponents()
        {
            GameObject[] gO = GameObject.FindGameObjectsWithTag("Opponent");
            foreach (GameObject go in gO)
            {
                Destroy(go);
            }
        }
    }
}
