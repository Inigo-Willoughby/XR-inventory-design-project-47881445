using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class Door : MonoBehaviour
{
    [SerializeField] private XRSocketInteractor[] sockets;
    [SerializeField] private GameObject DoorObject;

    private bool checkIfSocketsFull()
    {
        foreach (XRSocketInteractor socket in sockets)
        {
            if(!socket.hasSelection)
            {
                return false;
            }
        }
       return true;
    }

    public void TryUnlock()
    {
        DoorObject.SetActive(!checkIfSocketsFull());
    }
}
