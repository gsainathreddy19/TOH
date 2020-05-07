using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class instruction : MonoBehaviour
{
    public bool trig = false;
    public GameObject txt;
    private bool correct = false;
    public GameObject parent;
    private static int step = 0,count=0;
    private string[] source = new string[7] { "cylinder1", "cylinder1", "cylinder3", "cylinder1", "cylinder2", "cylinder2", "cylinder1" };
    private string[] destination = new string[7] { "cylinder3", "cylinder2", "cylinder2", "cylinder3", "cylinder1", "cylinder3", "cylinder3" };
    private string[] name = new string[7] { "DiskPink", "DiskViolet", "DiskPink", "DiskGreen", "DiskPink", "DiskViolet", "DiskPink" };

    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(parent.name.Equals(name[step]));
        /*
        for(int i = 5;i>0;i--)
        {
            for (int j = 0; j < 100000000; j++) { }
          
            txt.GetComponent<Text>().text = "------------------starts in"+i+"--------------------";
        }
        txt.GetComponent<Text>().text = "--------------------GO-------------------";
        for (int j = 0; j < 100000000; j++) { }
        txt.GetComponent<Text>().text = "Move " +name[step]+" from " +source[step] + " to " + destination[step];
        Debug.Log("source :" + source[step] + "Destination is" + destination[step]);
       // txt.GetComponent<Text>().text = "hello";
    */
        txt.GetComponent<Text>().text = "Move " + name[step] + " from " + source[step] + " to " + destination[step];


    }

    // Update is called once per frame
    void Update()
    {

        if(parent.transform.position.y <= 589.85 && trig)
        {
            txt.GetComponent<Text>().text = "---------------------WRONG MOVE-------------------";
            Debug.Log("wrong move");
            this.GetComponentInParent<Leap.Unity.Interaction.InteractionBehaviour>().enabled = false;
            parent.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            parent.transform.position = pos;
            trig = false;
        }
       
        if (count > 2)
        {
            if (parent.name.Equals(name[step]))
            {
                //this.GetComponentInParent<Rigidbody>().constraints = RigidbodyConstraints.None;
                //this.GetComponentInParent<Leap.Unity.Interaction.InteractionBehaviour>().enabled = true;
            }
            else
            {
               // this.GetComponentInParent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
               // this.GetComponentInParent<Leap.Unity.Interaction.InteractionBehaviour>().enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (count > 2)
        {
            if (other.CompareTag(destination[step]))
            {
                if (step < 6)
                {
                    this.GetComponentInParent<Leap.Unity.Interaction.InteractionBehaviour>().enabled = true;
                    //txt.GetComponent<Text>().text = "--------Step " + step + " is successfully done-------";
                    step++;

                    
                    //for (int j = 0; j < 200000000; j++) { }
                    txt.GetComponent<Text>().text = "Move " + name[step] + " from " + source[step] + " to " + destination[step];
                    Debug.Log("source :" + source[step] + "Destination is" + destination[step]);
                }
                else
                {
                    
                    txt.GetComponent<Text>().text = "---------------CONGRATULATIONS----------------";
                }
            }
            else if(other.CompareTag(source[step]))
                    {
                
                this.GetComponentInParent<Leap.Unity.Interaction.InteractionBehaviour>().enabled = true;
                StartCoroutine(corotine());
                for (int j = 0; j < 100000000; j++) { }
                txt.GetComponent<Text>().text = "Move " + name[step] + " from " + source[step] + " to " + destination[step];

            }
            else
            {
                txt.GetComponent<Text>().text = "---------------------WRONG MOVE-------------------";
                Debug.Log("wrong move");
                this.GetComponentInParent<Leap.Unity.Interaction.InteractionBehaviour>().enabled = false;
                parent.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                parent.transform.position = pos;

            }
        }
        count++;
        trig = false;
    }
    private void OnTriggerExit(Collider other)
    {

        // Debug.Log(pos);
        if (other.CompareTag("cylinder1"))
        {
            pos.x = -97.1f;
            pos.y = 589.9f;
            pos.z = 183.5f;
            //Debug.Log(pos + "exited from" + other.name);
            

        }
        if (other.CompareTag("cylinder2"))
        {
            pos.x = -97.3f;
            pos.y = 589.9f;
            pos.z = 183.5f;
           // Debug.Log(pos + "exited from" + other.name);


        }
        if (other.CompareTag("cylinder3"))
        {
            pos.x = -97.5f;
            pos.y = 589.9f;
            pos.z = 183.5f;
           // Debug.Log(pos + "exited from" + other.name);

        }
        //trig = true;
    }
    IEnumerator corotine()
    {
        yield return new WaitForSeconds(5000);
    }
    IEnumerator corotin()
    {
        yield return new WaitForSeconds(5000);
    }
}
