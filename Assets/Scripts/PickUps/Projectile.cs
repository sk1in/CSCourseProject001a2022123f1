using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ParticleSystem particleSys;
    //[SerializeField] private TurnManager playerActive;
    private Transform shootingPoint;
   
    public float moveSpeed = 5.0f;
    float changeAngleX;
    float changeAngleY;

    //private void Awake()
    //{    
    //    shootingPoint = GameObject.Find(TurnManager.ActiveObject()).transform.GetChild(2).GetChild(0).transform;
    //    //playerActive.transform.GetChild(2).GetChild(0).GetChild(0).transform;

    //    Debug.Log("16-0 " + shootingPoint);
    //}

    private void Start()
    {
        //Out of bounds - Missing when running since object moves to its place of use. It exists in 02000, child 0 - child 2 ...
        //shootingPoint = GameObject.Find(TurnManager.ActiveObject()).transform.GetChild(2).GetChild(0).GetChild(0).transform;
        shootingPoint = GameObject.Find(TurnManager.ActiveObject()).transform.GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).transform;
    }

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
