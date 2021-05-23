using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HandAttachManager : MonoBehaviour
{
    public GameSceneManager sceneManager;
    public GameEvent leftAttach;
    public GameEvent rightAttach;
    public void CheckIfReattach()
    {
        if (sceneManager.GetCurrentScene().leftAttachedAtStart)
        {
            leftAttach.Raise();
        }
        if (sceneManager.GetCurrentScene().rightAttachedAtStart)
        {
            rightAttach.Raise();
        }
    }
}
