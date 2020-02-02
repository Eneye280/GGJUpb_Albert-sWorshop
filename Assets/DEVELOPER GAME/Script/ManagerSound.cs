using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSound : MonoBehaviour
{
    internal static ManagerSound managerSound;
    internal static ManagerSound instance
    {
        get
        {
            if(!managerSound)
            {
                managerSound = FindObjectOfType<ManagerSound>();

                if(!managerSound)
                {
                    var singleton = new GameObject(typeof(ManagerSound).ToString());
                    managerSound = singleton.AddComponent<ManagerSound>();
                }
            }
            return managerSound;
        }
    }

    [SerializeField] internal AudioSource audioBackgroundGamePlay;

    #region Audio Effect
    [SerializeField] internal AudioSource audioEffectGamePlay;
    [SerializeField] internal AudioClip[] audioClipEffect;
    #endregion

}
