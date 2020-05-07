using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paperdrop : MonoBehaviour
{
    public GameObject paper,mediator;
    // Start is called before the first frame update
    public void Start()
    {

        mediator.GetComponent<mediator>().set = false;
           // paper.GetComponent<simplechange>().onceGrasped = false;
           // paper.GetComponent<BoxCollider>().enabled = false;
        
    }
    public void ok()
    {
        mediator.GetComponent<mediator>().set = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
