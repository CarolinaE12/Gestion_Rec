using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject[] objects; // Los objetos que deben colocarse
    private bool[] isObjectInPlace;

    void Start()
    {
        isObjectInPlace = new bool[objects.Length];
    }

    public void SetObjectInPlace(int index, bool inPlace)
    {
        isObjectInPlace[index] = inPlace;
    }

    public bool AreAllObjectsInPlace()
    {
        foreach (bool inPlace in isObjectInPlace)
        {
            if (!inPlace)
            {
                return false;
            }
        }
        return true;
    }
}

