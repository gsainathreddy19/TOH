using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private bool correct = false;
    public GameObject parent;
    private int step = 0;
    private string[] source = new string[7]{"cylinder1","cylinder1","cylinder3","cylinder1","cylinder2","cylinder2","cylinder1"};
    private string[] destination = new string[7] { "cylinder3", "cylinder2", "cylinder2", "cylinder3", "cylinder1", "cylinder3", "cylinder3" };
    private string[] name = new string[7] { "DiskPink", "DiskViolet", "DiskPink", "DiskGreen", "DiskPink", "DiskViolet", "DiskPink" };

    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("source :" + source[step] + "Destination is" + destination[step]);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(destination[step]))
        {
            Debug.Log("source :" + source[step] + "Destination is" + destination[step]);
            step++;
        }
        else
        {
            parent.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            parent.transform.position = pos;

        }
    }
    private void OnTriggerExit(Collider other)
    {

        // Debug.Log(pos);
        if (other.CompareTag("cylinder1"))
        {
            pos.x = -97.1f;
            pos.y = 589.9f;
            pos.z = 183.5f;
            Debug.Log(pos + "exited from" + other.name);
            

        }
        if (other.CompareTag("cylinder2"))
        {
            pos.x = -97.3f;
            pos.y = 589.9f;
            pos.z = 183.5f;
            Debug.Log(pos + "exited from" + other.name);
           

        }
        if (other.CompareTag("cylinder3"))
        {
            pos.x = -97.5f;
            pos.y = 589.9f;
            pos.z = 183.5f;
            Debug.Log(pos + "exited from" + other.name);

        }
    }
}
