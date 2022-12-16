using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWeaponsInventory : MonoBehaviour
{
    [SerializeField] GameObject disable0A;
    [SerializeField] GameObject disable0B;
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject txtWeaponA;
    [SerializeField] GameObject txtWeaponAAwaiting;
    [SerializeField] GameObject txtWeaponB;
    [SerializeField] GameObject txtWeaponBAwaiting;

    bool a, b;

    void Update()
    {
        updateA();
        updateB();
        Debug.Log("21c1: " + a);
        Debug.Log("21c2: " + b);
        if (Input.GetKeyDown(KeyCode.I))
        {
            //txtWeaponA.SetActive(false);
            if (inventory.activeSelf)
            {
                inventory.SetActive(false);

                if (!a && !txtWeaponA.activeSelf) txtWeaponAAwaiting.SetActive(true);
                if (!b && !txtWeaponB.activeSelf) txtWeaponBAwaiting.SetActive(true);
            }
            else
            {
                inventory.SetActive(true);

                txtWeaponAAwaiting.SetActive(false);
                txtWeaponBAwaiting.SetActive(false);
                txtWeaponA.SetActive(false);
                txtWeaponB.SetActive(false);
            }
        }               
    }

    private void updateA()
    {
        if (PickupManager.GetInstance().SetWeaponA())
        {
            disable0A.SetActive(false);
            txtWeaponAAwaiting.SetActive(false);
            if(!inventory.activeSelf)
                txtWeaponA.SetActive(true);
            a = true;
            //Debug.Log("21a: " + a);
        }
    }

    private void updateB()
    {
        if (PickupManager.GetInstance().SetWeaponB())
        {
            //Debug.Log("20-0: " + PickupManager.GetInstance().SetWeaponB());
            disable0B.SetActive(false);
            txtWeaponBAwaiting.SetActive(false);
            if (!inventory.activeSelf)
                txtWeaponB.SetActive(true);
            b = true;
            //Debug.Log("21b: " + b);
        }
    }
}
