using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boiler : MonoBehaviour
{
    [SerializeField]
    private int energy = 100;

    [SerializeField]
    private float reductionDelay = .5f;

    [SerializeField]
    private Light pointLight;

    private void Start()
    {
        StartCoroutine(ReduceEnergy(reductionDelay));
    }

    IEnumerator ReduceEnergy(float delay)
    {
        if(energy > 0)
        {
            energy--;
            pointLight.intensity = GetLightIntensity();

            if (energy == 0)
                LoadAsync.instance.LoadScene(5);
        }
        //else
        //    LoadAsync.instance.LoadScene(5);

        yield return new WaitForSeconds(delay);
        StartCoroutine(ReduceEnergy(delay));
    }

    public void AddEnergy(int power)
    {
        energy += power;
        if(energy > 100)
        {
            energy = 100;
        }
    }

    public float GetLightIntensity()
    {
        return float.Parse((energy * 0.02).ToString());
    }

}
