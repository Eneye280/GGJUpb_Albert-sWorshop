using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerClient : MonoBehaviour
{
    internal static ManagerClient managerClient;
    internal static ManagerClient instance
    {
        get
        {
            if(!managerClient)
            {
                managerClient = FindObjectOfType<ManagerClient>();

                if(!managerClient)
                {
                    var singleton = new GameObject(typeof(ManagerClient).ToString());
                    managerClient = singleton.AddComponent<ManagerClient>();
                }
            }
            return managerClient;
        }
    }

    #region Controller Instance Client
    private GameObject instanceClient;
    [SerializeField] private GameObject clientPrefab;

    [SerializeField] private Transform positionInstanceClient;
    [SerializeField] internal Transform[] positionFinal;

    [SerializeField] internal Transform parentClient; 
    #endregion

    #region Controller Time Invoke Client
    [Range(0, 50)]
    [SerializeField] internal float timeFirInstance;
    [Range(0, 50)]
    [SerializeField] internal float timeRepeating;
    #endregion

    public bool isTutorial;


    [SerializeField]
    private void Start()
    {
        if (!isTutorial)
        {
            InvokeRepeating("CallInvokeClient", timeFirInstance, timeRepeating);
        }
        else
        {
            CallInvokeClient();
        }
    }

    private void CallInvokeClient()
    {
        instanceClient = Instantiate(clientPrefab,positionInstanceClient.position, Quaternion.identity);
        instanceClient.transform.SetParent(parentClient);
    }
}
