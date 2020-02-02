using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairController : MonoBehaviour
{
    public int index;
    public Image needReference;
    public Image repairBar;

    public void ActiveNeedReference()
    {
        needReference.gameObject.SetActive(true);
        repairBar.gameObject.SetActive(true);
    }
}
