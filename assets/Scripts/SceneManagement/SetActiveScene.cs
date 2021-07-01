using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetActiveScene : MonoBehaviour
{
    public Scene scene;
    private void OnEnable()
    {
        SceneManager.sceneLoaded += SetActive;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SetActive;
    }
    private void Start()
    {

        SceneManager.SetActiveScene(scene);
    }
    private void SetActive(Scene scene, LoadSceneMode mode)
    {
        SceneManager.SetActiveScene(scene);
    }
}
