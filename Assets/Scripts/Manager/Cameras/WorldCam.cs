using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCam : MonoBehaviour
{   //Own note, v1.x-.5 y+5 z+8.   v2.x-.5 y+5 z+8. -  v.3 x0 y7.57 z4.25, finally using v4. x0 y9.5 z11
    [SerializeField] private Vector3 distanceFromThePlayer;
    [SerializeField] private float speed;    

    void Update()
    {        
        Vector3 targetPosition = GameObject.Find(TurnManager.ActiveObject()).gameObject.transform.GetChild(1).transform.position + distanceFromThePlayer;
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }
}