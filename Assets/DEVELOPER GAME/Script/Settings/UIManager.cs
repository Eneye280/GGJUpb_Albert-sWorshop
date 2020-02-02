using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private static UIManager uiManager;
    internal static UIManager instance
    {
        get
        {
            if (!uiManager)
            {
                uiManager = FindObjectOfType<UIManager>();

                if (!uiManager)
                {
                    GameObject singleton = new GameObject(typeof(UIManager).ToString());
                    uiManager = singleton.AddComponent<UIManager>();
                }
            }
            return uiManager;
        }
    }

    [SerializeField] internal TextMeshProUGUI textScore;
    [SerializeField] internal Slider sliderCauldron;

    private void Start()
    {
        textScore.text = Score.instance.scoreInit.ToString();
    }
}
