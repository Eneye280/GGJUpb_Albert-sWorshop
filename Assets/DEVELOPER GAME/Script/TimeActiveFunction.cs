using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeActiveFunction : MonoBehaviour
{
    internal Animator anim;
    public float timeActive;

    private void Start()
    {
        anim = GetComponent<Animator>();
        Invoke("TimeFunction",timeActive);
    }

    public void TimeFunction()
    {
        anim.SetBool("active",true);
    }
}
