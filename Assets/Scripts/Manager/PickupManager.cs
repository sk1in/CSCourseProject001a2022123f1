    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    private static PickupManager instance;


    [SerializeField] GameObject weaponA;
    [SerializeField] GameObject weaponB;
    [SerializeField] GameObject holder;
    private bool giveA;
    private bool giveB;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static PickupManager GetInstance()
    {
        Debug.Log("012" + instance);
        return instance;
    }

    private void Update()
    {  
        if (weaponA.gameObject.transform.childCount > 1 && weaponA.transform.GetChild(0).gameObject.activeSelf)
        {
            Debug.Log("012aa: " + weaponA);
            giveA = true;
        }
        else
            giveA = false;

        Debug.Log("012aaa: " + weaponA);
        Debug.Log("012b: " + weaponB.gameObject.transform.childCount);


        //Consider changing : weaponB.gameObject.transform.childCount > 1, since it might not apply any longer.
        //if (weaponB.gameObject.transform.childCount > 1 && weaponB.transform.GetChild(0).gameObject.activeSelf)
        if (weaponB.transform.GetChild(0).gameObject.activeSelf)
        {
            Debug.Log("012ab: " + weaponB);
            Debug.Log("012abc: " + weaponB.transform.GetChild(0));
            giveB = true;
        }
        else
            giveB = false;

        Debug.Log("012aba: " + weaponB);
    }

    public GameObject SetWeaponA()
    {        
        if (giveA && weaponA.gameObject.transform.childCount > 1)
        {
            return weaponA.transform.GetChild(0).gameObject;
        }
        //Debug.Log("012c: " + weaponA);
        giveA = false;
        return null;
    }

    public GameObject SetWeaponB()
    {   
        if (giveB)
        {
            //Debug.Log("012dab: " + weaponB.transform.GetChild(0).transform.GetChild(0).gameObject);
            //Debug.Log("012da1: " + giveB);

            weaponB.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(true);
            return weaponB.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        }

        //Debug.Log("012d: " + weaponB);
            Debug.Log("012da3: " + giveB);
        giveB = false;
        return null;        
    }
}