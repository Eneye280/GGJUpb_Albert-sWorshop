using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSpawnerPointController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] allClients;

    [SerializeField]
    private GameObject[] allObjects;

    [SerializeField]
    private Transform pointDestination;

    [SerializeField]
    private Transform pointDelivery;

    [SerializeField]
    private float spawnerTime;

    [SerializeField]
    private int numberClients;

    [SerializeField]
    private bool canSpawner;

    public GameObject clientInPointDestination;


    private void Start()
    {
        StartCoroutine(RatSpawn());
    }

    IEnumerator RatSpawn()
    {
        int clientSpawned = 0;
        while (canSpawner && clientSpawned < numberClients)
        {
            int clientRandom = Random.Range(0, allClients.Length);
            GameObject clientSpawn = Instantiate(allClients[clientRandom], this.transform.position, Quaternion.identity);

            int objectRandom = Random.Range(0, allObjects.Length);
            GameObject objectRandomSelected = Instantiate(allObjects[objectRandom], this.transform.position, Quaternion.identity);
            clientSpawn.GetComponent<Client>().objectDeliver = objectRandomSelected;

            clientSpawn.GetComponent<Client>().pointDestination = pointDestination;
            clientSpawn.GetComponent<Client>().pointDelivery = pointDelivery;
            clientSpawn.transform.Rotate(0f, 180f, 0f); 
            clientSpawned++;
            canSpawner = !canSpawner;

            yield return new WaitForSeconds(spawnerTime);
            canSpawner = !canSpawner;
        }
    }
}
