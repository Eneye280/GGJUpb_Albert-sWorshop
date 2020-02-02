using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caldero : MonoBehaviour
{
    [SerializeField] internal int howMuchMoreUp;
    [SerializeField] internal string labelObject;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(labelObject))
        {
            Boiler.instance.AddEnergy(howMuchMoreUp);
            Score.instance.scoreInit += Score.instance.scoreGarbage;
            UIManager.instance.textScore.text = Score.instance.scoreInit.ToString();
        }
    }
}
