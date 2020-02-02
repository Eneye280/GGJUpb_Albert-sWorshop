﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadingbar : MonoBehaviour {

    private RectTransform rectComponent;
    private Image imageComp;
    public float speed = 0.0f;

    [SerializeField]
    private Color[] waitColors;
    
    public bool waiting;
   

    // Use this for initialization
    void Start () {
        rectComponent = GetComponent<RectTransform>();
        imageComp = rectComponent.GetComponent<Image>();
        imageComp.fillAmount = 0.0f;
    }

    void Update()
    {
        if (imageComp.fillAmount != 1f)
        {
            imageComp.fillAmount = imageComp.fillAmount + Time.deltaTime * speed;
            
        }

        if(imageComp.fillAmount > 0 && imageComp.fillAmount <0.25)
        {
            imageComp.color = waitColors[0];
        }
        else if(imageComp.fillAmount > 0.25 && imageComp.fillAmount < 0.50)
        {
            imageComp.color = waitColors[1];
        }
        else if (imageComp.fillAmount > 0.50 && imageComp.fillAmount < 0.75)
        {
            imageComp.color = waitColors[2];
        }
        else if (imageComp.fillAmount > 0.75 && imageComp.fillAmount < 1)
        {
            imageComp.color = waitColors[3];
        }


        //switch (imageComp.fillAmount)
        //{
        //    case 0.25f:
        //        imageComp.color = waitColors[1];
        //        break;

        //    case 0.50f:
        //        imageComp.color = waitColors[2];
        //        break;

        //    case 0.75f:
        //        imageComp.color = waitColors[3];
        //        break;

        //    case 1f:
        //        //Se estalla la cabeza
        //        break;
        //}
    }
}