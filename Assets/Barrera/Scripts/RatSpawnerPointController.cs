using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatSpawnerPointController : MonoBehaviour
{
    [SerializeField]
    private GameObject rat;

    [SerializeField]
    private float spawnerTime;

    [SerializeField]
    private int numberRats;

    [SerializeField]
    private bool canSpawner;


    private void Start()
    {
        StartCoroutine(RatSpawn());
    }

    IEnumerator RatSpawn()
    {
        int ratsSpawned = 0;
        while (canSpawner && ratsSpawned < numberRats)
        {
            Instantiate(rat, this.transform.position, Quaternion.identity);
            ratsSpawned++;
            canSpawner = !canSpawner;

            yield return new WaitForSeconds(spawnerTime);
            canSpawner = !canSpawner;
        }
    }
}
