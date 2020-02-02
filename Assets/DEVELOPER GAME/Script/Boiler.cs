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
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ReduceEnergy(reductionDelay));
    }

    IEnumerator ReduceEnergy(float delay)
    {
        if(energy > 0)
        {
            energy--;
            pointLight.intensity = GetLightIntensity();
            //print($"Energy: {energy}");
            if(energy == 0)
                print("Sin Energía");
        }
        else
            print("Sin Energía");
            
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

    float GetLightIntensity()
    {
        return float.Parse((energy * 0.02).ToString());
    }

}
