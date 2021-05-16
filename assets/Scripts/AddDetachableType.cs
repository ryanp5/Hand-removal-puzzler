using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDetachableType : MonoBehaviour
{
    private DisconnectOnTrigger disconnectOnTrigger;
    private DisconnetOnCollision disconnetOnCollision;
    private MeshRenderer meshRenderer;
    public Material CombinedMaterial;
    public Material original;
    private Material removal;
    private void Start()
    {
        disconnectOnTrigger = GetComponent<DisconnectOnTrigger>();
        disconnetOnCollision = GetComponentInChildren<DisconnetOnCollision>();
        meshRenderer = GetComponent<MeshRenderer>();
        original = meshRenderer.material;
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    var detachObj = collision.collider.GetComponent<TypeOfDetachable>();
    //    if (detachObj != null)
    //    {
    //        if (detachObj.detachable.GetType() == typeof(Consumable)) {
    //            var detachToAdd = (Consumable)detachObj.detachable;
    //            SetMaterial(detachToAdd);
    //            AddDetachableOfType(detachToAdd.BoxToDetach);
    //            //collision.collider.attachedRigidbody.position = collision.collider.attachedRigidbody.position + Vector3.up * 100;
    //            Destroy(collision.collider.gameObject);
    //        }
    //    }
    //}
    //private void OnCollisionExit(Collision collision)
    //{
    //    var detachObj = collision.collider.GetComponent<TypeOfDetachable>();
    //    if (detachObj != null)
    //    {
    //        if (detachObj.detachable.GetType() == typeof(Consumable))
    //        {
    //            var detachToAdd = (Consumable)detachObj.detachable;
    //            RemoveDetachableOfType(detachToAdd.BoxToDetach);
    //            RemoveMaterial(detachToAdd);
    //        }
    //    }
    //}

    public void RemoveDetachableOfType(Consumable detachable)
    {
        disconnectOnTrigger.detachableType.Remove(detachable.BoxToDetach);
        disconnetOnCollision.detachableType.Remove(detachable.BoxToDetach);
        RemoveMaterial(detachable);
    }

    private void RemoveMaterial(Consumable detachable)
    {
        if (disconnectOnTrigger.detachableType.Count == 0)
        {
            meshRenderer.material = original;
        } else
        {
            //if (detachable.PortalMat != removal) { }
            meshRenderer.material = removal;

        }
    }

    public void AddDetachableOfType(Consumable detachable)
    {
        if (!disconnectOnTrigger.detachableType.Contains(detachable.BoxToDetach))
        {
            disconnectOnTrigger.detachableType.Add(detachable.BoxToDetach);
            disconnetOnCollision.detachableType.Add(detachable.BoxToDetach);
            SetMaterial(detachable);
        }
    }

    private void SetMaterial(Consumable detachable)
    {
        if (disconnectOnTrigger.detachableType.Count == 0)
        {
            meshRenderer.material = original;
        } else if (disconnectOnTrigger.detachableType.Count == 1)
        {
            meshRenderer.material = detachable.PortalMat;
            removal = detachable.PortalMat;
        }
        else if (disconnectOnTrigger.detachableType.Count == 2)
        {
            meshRenderer.material = CombinedMaterial;
        }
    }

}
