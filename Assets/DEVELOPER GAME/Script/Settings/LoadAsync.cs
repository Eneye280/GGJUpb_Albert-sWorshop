using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

public class LoadAsync : MonoBehaviour
{
    private static LoadAsync loadAsyn;
    internal static LoadAsync instance
    {
        get
        {
            if(!loadAsyn)
            {
                loadAsyn = FindObjectOfType<LoadAsync>();

                if(!loadAsyn)
                {
                    var singleton = new GameObject(typeof(LoadAsync).ToString());
                    loadAsyn = singleton.AddComponent<LoadAsync>();
                }
            }
            return loadAsyn;
        }
    }

    private AsyncOperation asyncOperation;
    private WaitForSeconds delayScene = new WaitForSeconds(1f);

    public bool automatic;
    public int sceneLoad;

    [Space(25)]
    [Range(0, 100)]
    [SerializeField] internal float howMuchIsTheProgress;
    [SerializeField] internal string nameTextProgress;
    [SerializeField] internal Slider sliderProgress;

    [Space(25)]
    public TextMeshProUGUI textInProgress;

    [Space(25)]
    public GameObject panelLoadAsync;

    private void Awake()
    {
        panelLoadAsync.SetActive(false);

        if(automatic)
            StartCoroutine(CallLoadScene(sceneLoad));
    }

    public void LoadScene(int scene) => StartCoroutine(CallLoadScene(scene));

    private IEnumerator CallLoadScene(int scene)
    {
        yield return null;

        asyncOperation = SceneManager.LoadSceneAsync(scene);

        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            panelLoadAsync.SetActive(true);

            sliderProgress.value = asyncOperation.progress;
            textInProgress.text = nameTextProgress + "<b>" + (asyncOperation.progress * howMuchIsTheProgress) + "</b>" + "%";
            asyncOperation.allowSceneActivation = true;

            yield return null;
        }
    }
}
