using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        print(v);
    }
}
