using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeedRepairController : MonoBehaviour
{
    public int index;
    public Sprite[] allNeedReferences;
    public Sprite[] allEmoticons;
    public Image needReference;
    // Start is called before the first frame update
    void Start()
    {
        needReference.gameObject.SetActive(true);
        index = Random.Range(0, allNeedReferences.Length);
        needReference.sprite = allNeedReferences[index];
    }
}
