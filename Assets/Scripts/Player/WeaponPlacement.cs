using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPlacement : MonoBehaviour
{
    //public Transform objectA;
    //public Transform objectB;
    public Transform objectC;
    public Transform objectD;

    public Transform objectA, objectB;
    [SerializeField] private GameObject itemA;
    [SerializeField] private GameObject itemB;

    GameObject loadItemA, loadItemB;

    private int once;


    //[SerializeField] private TurnManager playerActive;

    // UnityException: Transform child out of bounds , ?, it was the instance playerActive which did not possess any object.
    //When solved, a new issue, could not be called from awake becasue it seems that it does not exists yet.
    private void Awake()
    {
        //GameObject.Find(TurnManager.ActiveObject()).gameObject.transform.GetChild(1).transform.position

        //objectA = GameObject.Find(TurnManager.ActiveObject()).transform.GetChild(2).transform;            
        //Debug.Log("14: " + objectA);
        //objectB = GameObject.Find(TurnManager.ActiveObject()).transform.GetChild(0).GetChild(2).transform;        
    }

    void Start()
    {
        //objectA = playerActive.transform.GetChild(2).gameObject.transform;
        //Debug.Log("14: " + objectA);
        //objectB = playerActive.transform.GetChild(0).GetChild(2).transform;


        //Debug.Log("14: " + playerActive.transform.GetChild(2).gameObject.transform);
        //Debug.Log("14: " + playerActive. transform.GetChild(2).gameObject.transform);

        // Uknown behaviour: 'Start' being called multiple times since the script is shared between multiple objects.
        // Perhaps changing to 'objectA' private from public. Trying with 'once' and turning the script off manually on Unity and
        // then on to keep it on which stop the error 'out of bounds' caused by line 75. 
        once = 1;
        if (once > 0)
        {

            Debug.Log("14aa0: " + once);
            objectA = GameObject.Find(TurnManager.ActiveObject()).transform.GetChild(2).transform;
            Debug.Log("14aa: " + objectA);
            objectB = GameObject.Find(TurnManager.ActiveObject()).transform.GetChild(0).GetChild(2).transform;
            once = 0;
            Debug.Log("14aa1 : " + once);

        }

        objectA.position = objectB.position;
        objectA.parent = objectB;
    }

    private void Update()
    {
        loadItemA = PickupManager.GetInstance().SetWeaponA();
        loadItemB = PickupManager.GetInstance().SetWeaponB();
        Debug.Log("14ab: " + loadItemA);

        if (loadItemA)
        {
            GameObject toParent;
            Debug.Log("14ac: " + loadItemA);
           
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
