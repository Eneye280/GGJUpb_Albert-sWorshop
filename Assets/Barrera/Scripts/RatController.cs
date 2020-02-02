using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RatController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject[] allTrash;

    [SerializeField]
    private GameObject trashSelected;

    [SerializeField]
    private GameObject[] allRatSpawnerPoints;

    [SerializeField]
    private Transform pointSelected;

    [SerializeField]
    private Transform grabTrashPoint;

    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private float speed;

    [SerializeField]
    private bool touchPlayer = false;

    [SerializeField]
    private bool grabTrash;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        grabTrashPoint = this.gameObject.transform.GetChild(0).transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        agent.speed = speed;
        allTrash = GameObject.FindGameObjectsWithTag("Trash");
        allRatSpawnerPoints = GameObject.FindGameObjectsWithTag("RatSpawnerPoint");
    }

    // Update is called once per frame
    void Update()
    {
        SearchTarget();
    }

    private void SearchTarget()
    {
        if(touchPlayer)
        {
            if(grabTrash)
            {
                agent.SetDestination(pointSelected.position);
            }
            else
            {
                agent.SetDestination(trashSelected.transform.position);
            }
        }
        else
        {
            agent.SetDestination(player.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(!touchPlayer)
            {
                touchPlayer = true;
                int trashIndex = Random.Range(0, allTrash.Length);
                trashSelected = allTrash[trashIndex];
            }
        }
        else if(other.tag == "Trash")
        {
            if(touchPlayer)
            {
                grabTrash = true;
                trashSelected.transform.parent = grabTrashPoint;
                trashSelected.transform.localPosition = Vector3.zero;
                //trashSelected.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

                int pointIndex = Random.Range(0, allRatSpawnerPoints.Length);
                pointSelected = allRatSpawnerPoints[pointIndex].transform;
            }
        }
    }
}
