using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Boiler : MonoBehaviour
{
    private static Boiler boiler;
    internal static Boiler instance
    {
        get
        {
            if(!boiler)
            {
                boiler = FindObjectOfType<Boiler>();

                if(!boiler)
                {
                    GameObject singleton = new GameObject(typeof(Boiler).ToString());
                    boiler = singleton.AddComponent<Boiler>();
                }
            }
            return boiler;
        }
    }

    [SerializeField]
    private int energy = 100;

    [SerializeField]
    private float reductionDelay = .5f;

    [SerializeField]
    private Light pointLight;


    [Space(25)]
    [SerializeField] internal int addEnergyCauldron;

    private void Start()
    {
        StartCoroutine(ReduceEnergy(reductionDelay));
    }

    private void Update()
    {
        UIManager.instance.sliderCauldron.value = (float)energy;
    }

    IEnumerator ReduceEnergy(float delay)
    {
        if(energy > 0)
        {
            energy--;
            //pointLight.intensity = GetLightIntensity();
            pointLight.intensity = energy * Time.deltaTime;

            if (energy == 0)
                LoadAsync.instance.LoadScene(5);
        }

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

    //public float GetLightIntensity()
    //{
    //    return float.Parse((energy * 0.02).ToString());
    //}

}
