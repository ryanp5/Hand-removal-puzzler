using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;

[CreateAssetMenu(menuName = "ScriptableObjects/SceneManager")]
public class GameSceneManager : ScriptableObject
{
    public GameEvent OnLoadStart;
    public GameEvent OnLoadEnd;
    public List<GameScene> gameScenes = new List<GameScene>();
    public int gameSceneIndex;
    private GameScene currentScene;
    public bool isLoading = false;
    //Fade in/fade out components
    //private void Awake()
    //{
    //    SceneManager.sceneLoaded += SetActiveScene;
    //}
    //private void OnDestroy()
    //{
    //    SceneManager.sceneLoaded -= SetActiveScene;
    //}
    public GameScene GetCurrentScene()
    {
        return gameScenes[gameSceneIndex];
    }
    public GameScene GetNextScene()
    {
        return gameScenes[gameSceneIndex+1];
    }
    public void ReloadCurrentScene()
    {
        LoadNewScene(gameSceneIndex);
    }
    public void LoadNextScene()
    {
        var nextScene = gameScenes[gameSceneIndex + 1];
        if (nextScene != null)
        {
            LoadNewScene(gameSceneIndex +1);
        }
        else
        {
            Debug.Log("Last Scene");
        }
    }
    public void LoadMainMenu()
    {
        if (SceneManager.GetActiveScene().name != gameScenes[0].sceneName)
            LoadNewScene(0);
    
    }
    public void LoadNewScene(int sceneId)
    {
        if (!isLoading)
        {
            LoadScene(sceneId);
        }
    }
    public async void LoadScene(int sceneId)
    {
        isLoading = true;
            OnLoadStart.Raise();
            await WaitForFade(2000);
            UnLoadScene(sceneId);
            gameSceneIndex = sceneId;
            LoadNew(sceneId);

        isLoading = false;
    }
    
    public async void UnLoadScene(int sceneId)
    {
        AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        while (!unloadOperation.isDone)
        {
            await Task.Yield();
        }
    }
    private async void LoadNew(int sceneId)
    {
       AsyncOperation loadOperation = SceneManager.LoadSceneAsync(gameScenes[sceneId].sceneName, LoadSceneMode.Additive);
       
        while (!loadOperation.isDone)
        {
            await Task.Yield();
        }
        OnLoadEnd.Raise();
    }

    public async Task WaitForFade(int time)
    {
        await Task.Delay(time);
    }

    //private void SetActiveScene(Scene scene, LoadSceneMode mode)
    //{
    //    SceneManager.SetActiveScene(scene);
    //}


}
