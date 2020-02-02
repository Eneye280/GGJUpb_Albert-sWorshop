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
    [SerializeField] internal GameObject particleEpxlosion;

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
            {
                particleEpxlosion.SetActive(true);
                ManagerSound.instance.audioEffectGamePlay.clip = ManagerSound.instance.audioClipEffect[0];
                ManagerSound.instance.audioEffectGamePlay.Play();
                StartCoroutine(TimeExplosion());
            }
                
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

    IEnumerator TimeExplosion()
    {
        yield return new WaitForSeconds(2f);
        LoadAsync.instance.LoadScene(5);
    }
}
