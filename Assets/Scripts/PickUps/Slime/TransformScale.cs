using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformScale : MonoBehaviour
{   
    void LateUpdate()
    {
        //this.transform.localScale = new Vector3(7f, 1f, 50f);
        this.transform.localScale = new Vector3(1.1f, 1f, 7f);
    }
}
