using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private float yRotation;
    
    void Update()
    {
        transform.Rotate(new Vector3(Random.value, Time.deltaTime * yRotation, Random.value));
    }

    private void OnTriggerEnter(Collider other)
    {
        //Destroy(gameObject);
        //Debug.Log("Root" + transform.root.GetChild(0));

        if (transform.parent.parent.gameObject.name == "Slime")
        {
            Debug.Log("Root" + transform.parent.parent.gameObject.name);
            //transform.parent.parent.gameObject.SetActive(false);
            transform.parent.parent.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            transform.parent.parent.gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            //transform.parent.parent.gameObject.transform.GetChild(0).GetChild(2).transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log("Root2" + transform.parent.parent.gameObject.transform.GetChild(0).GetChild(1));
            transform.parent.gameObject.SetActive(false);
        }
        else
        {
            transform.parent.gameObject.SetActive(false);
            transform.parent.parent.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            transform.parent.parent.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(true);
            //Debug.Log("Roota1 " + transform.parent.gameObject);
            //Debug.Log("Roota2 " + transform.parent.parent.gameObject.transform.GetChild(0).gameObject);
            //Debug.Log("Roota3 " + transform.parent.parent.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject);
        }


    }    
}
