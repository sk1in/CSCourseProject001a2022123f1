using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{   
    [SerializeField] private float yRotation;

    void Update()
    {
       transform.Rotate(new Vector3(Random.value,Time.deltaTime * yRotation, Random.value)); 
    }
}
