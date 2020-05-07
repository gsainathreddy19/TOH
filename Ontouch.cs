using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ontouch : MonoBehaviour
{
    public GameObject obje;
    public GameObject scissor;
    public bool opt = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        Debug.Log("colided");
        if (opt && scissor.GetComponent<attachScissor>().onceGrasped )
        {
            Debug.Log("entered");
            if(thing.Cut(collision.transform, transform.position, obje))
            {
                Debug.Log("cut is done");
            }
        }
    }
}
