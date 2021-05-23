using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/Scene")]
public class GameScene : ScriptableObject
{
    [Header("Information")]
    public string sceneName;

    public bool leftAttachedAtStart;
    public bool rightAttachedAtStart;
    public string LevelUIText;
}
