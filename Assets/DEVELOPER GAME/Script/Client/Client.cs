using UnityEngine.AI;
using UnityEngine;
using System;

public class Client : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent navMeshAgent;
    [SerializeField]
    private bool deliveredObject = false;
    [SerializeField]
    private Transform objectDeliverPosition;
    [SerializeField]
    private float clientSpeed;
    [SerializeField]
    private GameObject waitBar;

    private Rigidbody rigidbody;
    private loadingbar loadingBar;

    public Transform pointDestination;
    public Transform pointDelivery;
    public GameObject objectDeliver;


    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(pointDestination.transform.position);
        objectDeliverPosition = transform.GetChild(0);
        rigidbody = GetComponent<Rigidbody>();
        navMeshAgent.speed = clientSpeed;
        loadingBar = waitBar.GetComponentInChildren<loadingbar>();
        waitBar.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(!deliveredObject && objectDeliver != null)
        {
            objectDeliver.transform.parent = objectDeliverPosition;
            objectDeliver.transform.localPosition = new Vector3(0, 0, 0);
            print("OK");
        }
    }

    private void DeliverObject()
    {
        deliveredObject = true;
        objectDeliver.transform.parent = pointDelivery;
        objectDeliver.transform.localPosition = new Vector3(0, 0, 0);
        objectDeliver = null;
        waitBar.SetActive(true);
        loadingBar.waiting = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PointDestination")
        {
            print("Enter");
            other.gameObject.GetComponentInParent<ClientSpawnerPointController>().clientInPointDestination = this.gameObject;
            EnableOrDisableNavMesh();
            Invoke("DeliverObject", 1);
        }
        if(other.tag == "Client")
        {
            EnableOrDisableNavMesh();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Client" && !deliveredObject)
        {
            print("Exit");
            navMeshAgent.speed = clientSpeed;
        }
    }

    private void EnableOrDisableNavMesh()
    {
        if(navMeshAgent.enabled == true)
        {
            navMeshAgent.speed = 0;
        }
        else
        {
            navMeshAgent.speed = clientSpeed;
        }
    }

    private void Wait()
    {
        
    }
}
