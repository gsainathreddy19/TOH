using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop : MonoBehaviour
{
    public GameObject scissor;
    public GameObject cube;
    public GameObject han;
    // Start is called before the first frame update
    public void Start()
    {
        //scissor.GetComponent<BoxCollider>().enabled = true;
        scissor.GetComponent<attachScissor>().onceGrasped = false;
       
        han.GetComponent<scissrot>().set = false;
        //cube.GetComponent<simplechange>().onceGrasped = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
