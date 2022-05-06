using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;
using TMPro;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    [HideInInspector]public Animator animator;
    [SerializeField] TMP_Text rank;
    List<Transform> positions= new List<Transform>();
    GameObject[] gO;
   [HideInInspector] public bool isFinished;
    private void Start()
    {
        animator = GetComponent<Animator>();
        positions.Add(transform);
        gO = GameObject.FindGameObjectsWithTag("Opponent");
        foreach (GameObject g in gO)
        {
            positions.Add(g.transform);
        }
       isFinished = false;
       
    }
    private void Update()
    {
        if (Input.GetButton("Fire1")&&!isFinished)
        {
            PlayerMove();
        }
        else
        {
            animator.SetTrigger("Idle");
        }
        DetermineRank();
    }

    void PlayerMove()
    {
        Vector3 mousePos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Vector3 hitVector = hit.point;
            hitVector.y = transform.localPosition.y;

            if (hitVector.z >= transform.localPosition.z)
            {
               
                animator.SetTrigger("MoveOn");
                transform.position = Vector3.MoveTowards(transform.localPosition, hitVector, moveSpeed * Time.deltaTime);
               
            }
            else
                animator.SetTrigger("Idle");

        }
        else
            animator.SetTrigger("Idle");
    }
    
    void DetermineRank()
    {
        if (positions.Count == 1)
        {
            rank.text = "";
        }
        if(positions[1]!=null)
        {

        var rankList = positions.OrderByDescending(x => x.transform.position.z).ToList();
        int index = rankList.IndexOf(transform);
        rank.text = (index+1).ToString();
        }
    }

}
