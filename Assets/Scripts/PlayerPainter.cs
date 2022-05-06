using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerPainter : MonoBehaviour
{
    RaycastHit hit;

    [SerializeField]
    private float rayDistance;

    [SerializeField]
    private Color colorToPaint;

    [SerializeField]
    private GameObject paintIcon;

    PaintableObject paintable;



    public void SetColor(Color color)
    {
        color.a = 1;
        colorToPaint = color;
    }

    void Update()
    {
        if (paintable != null)
        {
            paintable.ToggleHighlight(false);
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance))
        {
            if (hit.collider.gameObject.tag == "Wall")
            {

            paintable = hit.collider.GetComponent<PaintableObject>();
            if (paintable.IsPainting == false && !paintable.NewColor.Equals(colorToPaint))
            {
                paintable.ToggleHighlight(true);
                paintIcon.SetActive(true);


                paintable.SetColor(colorToPaint);
                paintable.StartPainting();
                paintable.ToggleHighlight(false);
               


            }
            else
            {
                paintIcon.SetActive(false);
            }
            }

        }
        else
        {
            paintIcon.SetActive(false);
        }
    }


}
