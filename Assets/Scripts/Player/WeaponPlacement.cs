using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPlacement : MonoBehaviour
{
    public Transform objectA;
    public Transform objectB;

    void Start()
    {
        //Make ObjectA's position match objectB
        objectA.position = objectB.position;

        //Now parent the object so it is always there
        objectA.parent = objectB;
    }
}
