using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "ScriptableObjects/SceneManager")]
public class GameSceneManager : ScriptableObject
{
    public GameScene MenuScene;
    public List<GameScene> gameScenes = new List<GameScene>();
    public int gameSceneIndex;
    private GameScene currentScene;
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(gameScenes[gameSceneIndex].sceneName);
    }
    public void LoadNextScene()
    {
        var nextScene = gameScenes[gameSceneIndex + 1];
        if (nextScene != null)
        {
            SceneManager.LoadScene(nextScene.sceneName);
            gameSceneIndex++;
        }
        else
        {
            Debug.Log("Last Scene");
        }
    }
    public void LoadMainMenu()
    {
        if (SceneManager.GetActiveScene().name != MenuScene.name)
        SceneManager.LoadScene(MenuScene.name);
    
    }
    public void LoadScene(int sceneId)
    {
        SceneManager.LoadScene(gameScenes[sceneId].sceneName);
        gameSceneIndex = sceneId;
    }
    public void MainMenuLoadLastScene()
    {
        if (gameSceneIndex <= 0)
        {
            SceneManager.LoadScene(gameScenes[0].sceneName);
        } else
        {
            SceneManager.LoadScene(gameScenes[gameSceneIndex].sceneName);
        }
    }

   

}
