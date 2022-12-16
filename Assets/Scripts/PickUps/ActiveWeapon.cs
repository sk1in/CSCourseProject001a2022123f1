using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] GameObject weaponHolder;
    public bool active;

    void Update()
    {
        if (weaponHolder.activeSelf)
        {
        }
    }
}








//Future, find out why is giving out of bounds error, when items do exist.
//if (weaponHolder.activeSelf)
//{
//    //Giving error out of bounds. 
//    //If it exists in the holder and holder is activated.
//    //if (weaponHolder.transform.GetChild(0).gameObject.transform.childCount > 0)
//    //if (weaponHolder.transform.GetChild(0).childCount > 0)
//    //{
//    //    weaponHolder.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.SetActive(true);
//    //    Debug.Log("20a: " + weaponHolder.transform.GetChild(0).transform.childCount);
//    //    Debug.Log("20ab: " + weaponHolder.transform.GetChild(0).childCount);
//    //    Debug.Log("20ac: " + weaponHolder.transform.GetChild(0).gameObject);
//    //    Debug.Log("20ad: " + weaponHolder.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject);
//    //}

//    //Debug.Log("20a: " + weaponHolder);
//    //Debug.Log("20ab: " + transform.GetChild(1).gameObject);
//    //Debug.Log("20ac: " + this);
//}