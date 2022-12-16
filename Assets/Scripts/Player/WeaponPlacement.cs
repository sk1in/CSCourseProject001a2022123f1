using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPlacement : MonoBehaviour
{
    public Transform objectA;
    public Transform objectB;
    public Transform objectC;
    public Transform objectD;
    
    [SerializeField] private GameObject itemA;
    [SerializeField] private GameObject itemB;

    GameObject loadItemA, loadItemB;

    void Start()
    {        
        objectA.position = objectB.position;
        objectA.parent = objectB;
    }

    private void Update()
    {
        loadItemA = PickupManager.GetInstance().SetWeaponA();
        loadItemB = PickupManager.GetInstance().SetWeaponB();
        Debug.Log("14: " + loadItemA);

        if (loadItemA)
        {
            GameObject toParent;
            Debug.Log("14a: " + loadItemA);
           
            if (objectA.GetChild(0).transform.GetChild(0).childCount < 1)
            {
                toParent = Instantiate(loadItemA, itemA.transform.position, itemA.transform.rotation);

                //Debug.Log("14a1: " + toParent.transform.GetChild(1).gameObject);
                toParent.transform.GetChild(1).gameObject.SetActive(true);
                toParent.transform.parent = objectA.GetChild(0).transform.GetChild(0).gameObject.transform;
            }

            Debug.Log("14aba: " + objectA.GetChild(0).transform.GetChild(0).gameObject.transform);
        }

        if (loadItemB)
        {
            GameObject toParent;
            if (objectA.GetChild(1).transform.GetChild(0).childCount < 1)
            {
                toParent = Instantiate(loadItemB, itemA.transform.position, itemA.transform.rotation);
                toParent.transform.parent = objectA.GetChild(1).transform.GetChild(0).gameObject.transform;
            }
        }
    }
}
