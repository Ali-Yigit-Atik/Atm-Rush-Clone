using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidBug : MonoBehaviour
{
   

    
    void Update()
    {
        if (gameObject.CompareTag("money"))
        {
            gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
        }
    }
}
