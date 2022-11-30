using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCam : MonoBehaviour
{    
    [SerializeField] private Vector3 distanceFromThePlayer;
    [SerializeField] private float speed;    

    void Update()
    {        
        Vector3 targetPosition = GameObject.Find(TurnManager.ActiveObject()).gameObject.transform.GetChild(1).transform.position + distanceFromThePlayer;
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }
}