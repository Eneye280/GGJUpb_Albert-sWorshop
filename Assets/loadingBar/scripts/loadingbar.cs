using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadingbar : MonoBehaviour {

    private RectTransform rectComponent;
    private Image imageComp;
    public float speed = 0.0f;

    [SerializeField]
    private Color[] waitColors;
    [SerializeField]
    private GameObject client;
    
    public bool waiting;

    private NeedRepairController needRepairController;
   

    // Use this for initialization
    void Start () {
        needRepairController = client.GetComponent<NeedRepairController>();
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
            needRepairController.needReference.sprite = needRepairController.allEmoticons[0];
        }
        else if(imageComp.fillAmount > 0.25 && imageComp.fillAmount < 0.50)
        {
            imageComp.color = waitColors[1];
            needRepairController.needReference.sprite = needRepairController.allEmoticons[1];
        }
        else if (imageComp.fillAmount > 0.50 && imageComp.fillAmount < 0.75)
        {
            imageComp.color = waitColors[2];
            needRepairController.needReference.sprite = needRepairController.allEmoticons[2];
        }
        else if (imageComp.fillAmount > 0.75 && imageComp.fillAmount < 1)
        {
            imageComp.color = waitColors[3];
            needRepairController.needReference.sprite = needRepairController.allEmoticons[3];
        }
    }
}
