using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskScript : MonoBehaviour
{

    public bool itouched = false;
    public bool isCollidedWithCylinder = false;
    public Vector3 previousPosition;
    // Start is called before the first frame update
    void Start()
    {
       
        // previousPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
   
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log(this.name + " is collided with " + collision.name);
        if (collision.CompareTag("Disk"))
        {
            if (collision.transform.localScale.magnitude.CompareTo(this.transform.localScale.magnitude) < 0)
            {
                this.transform.position = previousPosition;
                Debug.Log(this.name);
            }
        }
       // this.GetComponent<BoxCollider>().enabled = false;


    }
}
