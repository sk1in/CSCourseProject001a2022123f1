using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMove : MonoBehaviour
{
    [SerializeField] GameObject position;
    float min = 0.5f;
    float minZ = 0.5f;
    float max = 1f;
    float maxZ = 1f;
   
    
    void Start()
    {
        min = transform.position.x;
        minZ = transform.position.z;
        max = transform.position.x + 0.1f;
        maxZ = transform.position.z + 0.1f;
    }

    void Update()
    {
        //Speed
        transform.position = new Vector3(Mathf.PingPong(Time.time / 12, max - min) + min, Mathf.PingPong(Time.time / 48, 0.005f), Mathf.PingPong(Time.time / 48, maxZ - minZ) + minZ);
    }
}




//Future


//public float addMore = 0.002f;

//Scale on parent
//7 1 81.5
//Scale n spheres 0.15. 0.04 2.11

//max = transform.position.x + 0.05f;
//maxZ = transform.position.z + 0.05f;


//transform.position = new Vector3(Mathf.PingPong(Time.time * 2, max - min) + min, transform.position.y, transform.position.z);

//Working inside the object
//transform.position = new Vector3(Mathf.PingPong(Time.time / 12, max - min) + min, transform.position.y, transform.position.z);
//Working inside the object, last
//transform.position = new Vector3(Mathf.PingPong(Time.time / 48, max - min) + min, Mathf.PingPong(Time.time / 48, 0.005f), Mathf.PingPong(Time.time / 48, maxZ - minZ) + minZ);


//transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);



//public enum OccilationFuntion { Sine, Cosine }
//public void Update()
//{
//    //to start at zero
//    StartCoroutine(Oscillate(OccilationFuntion.Sine, 1f));
//    //to start at scalar value
//    //StartCoroutine (Oscillate (OccilationFuntion.Cosine, 1f));
//}

//private IEnumerator Oscillate(OccilationFuntion method, float scalar)
//{
//    while (true)
//    {
//        if (method == OccilationFuntion.Sine)
//        {
//            transform.position = new Vector3(Mathf.Sin(Time.time) * scalar, transform.position.y, transform.position.z);
//        }
//        else if (method == OccilationFuntion.Cosine)
//        {
//            transform.position = new Vector3(Mathf.Cos(Time.time) * scalar, transform.position.y, transform.position.z);
//        }
//        yield return new WaitForEndOfFrame();
//    }
//}