using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{   
    [SerializeField] private float yRotation;
    [SerializeField] private float xRotation;

    void Update()
    {
       transform.Rotate(new Vector3(0,Time.deltaTime * yRotation, 0)); 
       transform.Rotate(new Vector3(Time.deltaTime * xRotation, 0, 0)); 
    }
}
