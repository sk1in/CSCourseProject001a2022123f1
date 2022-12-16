using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    
    [SerializeField] GameObject spheres;
    [SerializeField] GameObject getPosition;
    [SerializeField] GameObject getDistance;
    [SerializeField] GameObject getParent;
    [SerializeField] GameObject signHorizontal;
    [SerializeField] GameObject signVertical;
    [SerializeField] GameObject dropPosition;
    [SerializeField] GameObject dropFromHorizontal;
    [SerializeField] GameObject dropFromVertical;
    [SerializeField] GameObject weaponHolder;

    Vector3 isIdle;
    GameObject dropFrom;
    GameObject mass;
    GameObject resetThisHolder;
    GameObject resetThisSignHorizontal;
    GameObject resetThisSignVertical;

    public int amount = 4;
    float distance;
    float nextPosition = 0f;

    void Update()
    {
        Debug.Log("17c: " + dropPosition.transform.position);

        if (Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Horizontal") > 0)
        {
            distance = dropFromHorizontal.transform.position.x;
            dropFrom = dropFromHorizontal;
        }
        else if (Input.GetAxis("Vertical") < 0 || Input.GetAxis("Vertical") > 0)
        {
            distance = dropFromVertical.transform.position.x;
            dropFrom = dropFromVertical;
        }

        if (Input.GetKeyDown(KeyCode.V) && weaponHolder.activeSelf)
        {
            Debug.Log("17-test :   " + mass);

            Destroy(resetThisHolder);
            Destroy(resetThisSignHorizontal);
            Destroy(resetThisSignVertical);
            Destroy(mass);

            //Object holding the instantiated objects and images used as ground warnings.
            resetThisHolder = Instantiate(getParent);
            resetThisSignHorizontal = Instantiate(signHorizontal);
            resetThisSignVertical = Instantiate(signVertical);

            if (dropFromHorizontal.transform.position != isIdle)
            {
                for (int y = 0; y < amount; ++y)
                {
                    Debug.Log("17-d :   " + distance + "y:  " + y);
                    //mass = Instantiate(spheres, new Vector3(distance + nextPosition, spheres.transform.position.y, spheres.transform.position.z), Quaternion.identity);
                    mass = Instantiate(spheres, new Vector3(distance + nextPosition, dropFrom.transform.position.y, dropFrom.transform.position.z), Quaternion.identity);

                    //Future. Changing angles. Need more testing
                    //mass = Instantiate(spheres, new Vector3(distance + nextPosition, spheres.transform.position.y, spheres.transform.position.z), Quaternion.Euler(0, -90, 0));

                    distance = mass.transform.position.x;
                    nextPosition = 0.02f;

                    //Debugs
                    //Debug.Log("17-00 :    " + nextPosition
                    //Debug.Log("17-da :    " + distance + "ya:  " + y
                    //Debug.Log("17-db:    " + mass.transform.position);
                   
                    resetThisSignHorizontal.transform.position = new Vector3(dropFrom.transform.position.x - 0.2f, dropFrom.transform.position.y - 0.56f, dropFrom.transform.position.z);
                    resetThisSignHorizontal.SetActive(true);
                    resetThisSignHorizontal.transform.parent = dropPosition.transform;

                    resetThisSignVertical.transform.position = new Vector3(dropFrom.transform.position.x - 0.2f, dropFrom.transform.position.y - 0.16f, dropFrom.transform.position.z); ;
                    resetThisSignVertical.SetActive(true);
                    resetThisSignVertical.transform.parent = dropPosition.transform;
                   
                    mass.transform.parent = resetThisHolder.transform;

                    resetThisHolder.transform.parent = dropPosition.transform;
                    resetThisHolder.transform.position = dropFrom.transform.position;
                    resetThisHolder.SetActive(true);

                    //Debug.Log("17-c0 :   " + mass);                                                        
                    mass.SetActive(true);
                }
            }

            isIdle = dropFromHorizontal.transform.position;
        }
    }
}









//Backed
//Vector3 offset = new Vector3(2, 0, 2);
//Distance
//double num = (0.6459961 - 0.7461) * (-1);
//spheres.transform.position.x + distance = 0.7460938
//0.8454 - ((0.6459961) + (0.6459961 - 0.7461) * (-1)) 0.6459961 - 0.7461
//float distance = (float)num;
//float spacing = 0.5f;

//If needed
//Vector3 lastPosition = spheres.transform.position;
//Vector3 offsetVector = spheres.transform.position;

//For later
//Radius
//spheres.GetComponent<SphereCollider>().radius
//Instantiate(data.Cells[Random.Range(0, data.Cells.Length)]), new Vector3(x + (x * spacing), 0, y + (y * spacing)), Quaternion.identity); // Create a specific cell on position (x,y)
//lastPosition = mass.transform.position;
//mass.transform.position = getPosition.transform.position;
//spheresList.Add(mass);