using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private static Score score;
    internal static Score instance
    {
        get
        {
            if (!score)
            {
                score = FindObjectOfType<Score>();

                if (!score)
                {
                    GameObject singleton = new GameObject(typeof(Score).ToString());
                    score = singleton.AddComponent<Score>();
                }
            }
            return score;
        }
    }

    [SerializeField] internal int scoreInit;
    [SerializeField] internal int scoreGarbage;
    [SerializeField] internal int scoreClient;

    private void Start()
    {
        scoreInit = 50;
    }
}
