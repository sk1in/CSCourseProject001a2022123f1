using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ParticleSystem particleSys;
    public Transform shootingPoint;
   
    public float moveSpeed = 5.0f;
    float changeAngleX;
    float changeAngleY;

    private void Update()
    {

        particleSys.transform.position = shootingPoint.transform.position;

        changeAngleX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        changeAngleY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");


        if (Input.GetKeyDown(KeyCode.V))
        {

            if (changeAngleX > 0)
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
                particleSys.Play();
            }
            else if (changeAngleX < 0)
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
                particleSys.Play();
            }
            else if (changeAngleY > 0)
            {
                transform.rotation = Quaternion.Euler(0, 360, 0);
                particleSys.Play();
            }
            else if (changeAngleY < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                particleSys.Play();
            }

            Debug.Log("16-a " + changeAngleX);
            Debug.Log("16-b " + changeAngleY);
        }
    }
}

//Future
//It might need changes if the item is to be set/drop off and placed on the origin again. 
