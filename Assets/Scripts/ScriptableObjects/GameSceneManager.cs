using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "ScriptableObjects/SceneManager")]
public class GameSceneManager : ScriptableObject
{
    public List<GameScene> gameScenes = new List<GameScene>();
    public int gameSceneIndex;
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(gameScenes[gameSceneIndex].sceneName);
    }
    

}
