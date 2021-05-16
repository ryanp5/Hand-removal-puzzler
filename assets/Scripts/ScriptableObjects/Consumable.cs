using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Detachables/Consumable")]
public class Consumable : Detachable
{
    public Detachable BoxToDetach;
    public Material PortalMat;
}
