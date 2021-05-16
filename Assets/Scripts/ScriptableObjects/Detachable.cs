using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detachable : ScriptableObject
{
    public GameEvent itemDetached;
    public GameEvent itemAttached;

    public GameEvent Killed;
}
