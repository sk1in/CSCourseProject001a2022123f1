using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] weapons;

    [Header("Keys")]
    [SerializeField] private KeyCode[] keys;

    [Header("Settings")]
    [SerializeField] private float switchTime;
    private int selectedWeapon, wNumber;
    private float timeSinceLastSwitch;   


    private void Start()
    {
        timeSinceLastSwitch = 0f;
        Select(selectedWeapon);
    }

    private void Update()
    {
        //Store iterations for comparison 
        List<GameObject> o = new List<GameObject>();
        for (int i = 0; i < weapons.Length; i++)
        {
            //Just adding weapons available, after picking them up, still needs to update for when dropping weapons.
            if (weapons[i].transform.childCount > 0)
            {
                //Still needs to check if item already in list to add or reject, not necessary for now.
                o.Add(weapons[i].transform.gameObject);
                wNumber = o.Count;
            }
        }
        Debug.Log("19a : " + wNumber);
        //Creating keys
        if (keys == null) keys = new KeyCode[wNumber];
        Debug.Log("19ab : " + keys.Length);

        int previousSelectedWeapon = selectedWeapon;

        for (int i = 0; i < keys.Length; i++)
            if (Input.GetKeyDown(keys[i]) && timeSinceLastSwitch >= switchTime)
                selectedWeapon = i;

        if (previousSelectedWeapon != selectedWeapon) Select(selectedWeapon);

        timeSinceLastSwitch += Time.deltaTime;
        Debug.Log("19ac : " + selectedWeapon);
    }

    private void Select(int weaponIndex)
    {
        for (int i = 0; i < weapons.Length; i++)
            weapons[i].gameObject.SetActive(i == weaponIndex);

        OnWeaponSelected();
    }

    private void OnWeaponSelected() { }
}










//private void Update()
//{
//    //Vector3 force = transform.forward * 700f + transform.up * 300f;
//    //if (Input.GetKeyDown(KeyCode.V))
//    //{
//    //    GameObject newProjectile = Instantiate(projectilePrefab);
//    //    newProjectile.transform.position = shootingStartPosition.position;
//    //    //newProjectile.GetComponent<Projectile>().Initialize(force);
//    //}
//}


//________________________


//More work needed
//List<GameObject> o = new List<GameObject>();
//for (int i = 0; i < weapons.Length; i++)
//{
//    int v = i;
//    Debug.Log("19aa: " + i);
//    Debug.Log("19aa: " + weapons[i].transform);

//    Debug.Log("19-1" + o.Count);
//    if (weapons[i].transform.childCount > 0)
//    {
//        o.Add(weapons[i].transform.gameObject);
//        //o.Insert(i,weapons[i].transform.gameObject);
//        Debug.Log("19-" + o.Count);
//    }
//    if (weapons[i].transform.childCount > 0 && (weapons[i].transform != weapons[v].transform))
//    {
//        v = i;
//        if (weapons[i].transform.childCount > 0 && (weapons[i].transform != weapons[v].transform))
//            wNumber++;
//        Debug.Log("19ab: " + i);
//        Debug.Log("19abn: " + wNumber);
//        //if (wNumber != i)
//        //{
//        //    wNumber = i;
//        //    Debug.Log("19ac: " + i);
//        //}
//    }
//}
//Debug.Log("19a : " + wNumber);


//________________________
//To review
//Get key
//If item child !null
//    child active true
//    Raycast to aim towards forward direction
//else return with message none weapon