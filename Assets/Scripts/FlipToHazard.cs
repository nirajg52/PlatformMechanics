using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipToHazard : MonoBehaviour
{

    
    
    public const float rot = 0.3f;
    

    // Start is called before the first frame update
    void Start()
    {
       


    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(new Vector3(rot, 0f, 0f));
    }
}
