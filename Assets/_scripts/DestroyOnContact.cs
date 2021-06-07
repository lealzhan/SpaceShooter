using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        //print(other.name);
        if(other.tag == "Boundary")
        {
            return;
        }

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
