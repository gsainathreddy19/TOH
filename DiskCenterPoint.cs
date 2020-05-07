using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using Leap.Unity.Interaction;

public class DiskCenterPoint : MonoBehaviour
{
    public GameObject parent;
    private bool trig = false;
    private bool top = false;
    public static int top1=-1, top2=-1, top3=-1;
    public static float[] d1= new float[10];
    public static float[] d2 = new float[10];
    public static float[] d3 = new float[10];
    public static string[] s1 = new string[10];
    public static string[] s2 = new string[10];
    public static string[] s3 = new string[10];
    LeapProvider provider;
    private AudioSource source;
    public AudioClip source1;
    public AudioClip source2;
    private InteractionBehaviour _intObj;


    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        
        _intObj = GetComponent<InteractionBehaviour>();
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;

        
        //pos = GetComponentInParent<Transform>().position;
        //Debug.Log(pos);

    }

    // Update is called once per frame
    void Update()
    {
        top = false;
        if (top1 >= 0)
        {
           

            if (s1[top1].Equals(parent.transform.name))
            {
                //this.GetComponentInParent<Leap.Unity.Interaction.InteractionBehaviour>().enabled = true;
                parent.GetComponent<Leap.Unity.Interaction.InteractionBehaviour>().enabled = true;
                Debug.Log(s1[top1]);
                Debug.Log(parent.transform.name);
                Debug.Log(s1[top1].Equals(parent.transform.name));
                top = true;
            }

        }
        if (top2 != -1)
        {
            if (s2[top2].Equals(parent.transform.name))
            {
                //this.GetComponentInParent<Leap.Unity.Interaction.InteractionBehaviour>().enabled = true;
                parent.GetComponent<Leap.Unity.Interaction.InteractionBehaviour>().enabled = true;
                top = true;
            }

        }
        if (top3 != -1)
        {
            if (s3[top3].Equals(parent.transform.name))
            {
                //this.GetComponentInParent<Leap.Unity.Interaction.InteractionBehaviour>().enabled = true;
                 parent.GetComponent<Leap.Unity.Interaction.InteractionBehaviour>().enabled = true;
                top = true;
            }

        }

        if (!top && !trig)
        {
            //this.GetComponentInParent<Leap.Unity.Interaction.InteractionBehaviour>().enabled = false;
            parent.GetComponent<Leap.Unity.Interaction.InteractionBehaviour>().enabled = false;
            
        }


        //Debug.Log(d1[top1] + "    " + this.GetComponent<BoxCollider>().size.x);
       if (trig)
        {
            Frame frame = provider.CurrentFrame;
            try
            {
                Hand hand = frame.Hands[0];
            }
            catch (System.Exception e)
            {
                Debug.Log(e);
                //if (parent.transform.position.y <= 589.8)
                //{

                    parent.transform.position = pos;
                    parent.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                //}
            }
        }
        
        
        
       
        

    }
    /*
    void OnTriggerEnter(Collider other)
    {
        this.GetComponentInParent<DiskScript>().previousPosition = this.GetComponentInParent<Transform>().position;
        Debug.Log(this.name+ " entered trigger");
        if (other.CompareTag("Cylinder"))
        {
            //this.GetComponentInParent<DiskScript>().isCollidedWithCylinder = true;
            Debug.Log(this.name + "sript started");
            //this.GetComponentInParent<DiskScript>().enabled = true;

        }
    }*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cylinder1"))
        {

            trig = false;

            if (top1==-1)
            {
                top1++;
                d1[top1] = this.GetComponentInParent<BoxCollider>().size.x;
                s1[top1] = parent.transform.name;
                parent.transform.eulerAngles = new Vector3(0f, 0f, 0f);

                Debug.Log(d1[top1]+"added to stack " + this.GetComponentInParent<Transform>().name+" "+top1);
                this.GetComponentInParent<Leap.Unity.Interaction.InteractionBehaviour>().enabled = false;
                //source.PlayOneShot(source1);
            }
            else if(this.GetComponentInParent<BoxCollider>().size.x > d1[top1])
            {
                top1++;
                Debug.Log("invalid step");
                this.GetComponentInParent<Leap.Unity.Interaction.InteractionBehaviour>().enabled = false;
                parent.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                parent.transform.position = pos;
                source.PlayOneShot(source2);

            }
           else
            {
                top1++;
                d1[top1] = this.GetComponentInParent<BoxCollider>().size.x;
                s1[top1] = parent.transform.name;
                parent.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                Debug.Log("added to stack " + this.GetComponentInParent<Transform>().name);
                this.GetComponentInParent<Leap.Unity.Interaction.InteractionBehaviour>().enabled = false;
                //source.PlayOneShot(source1);
            }
            
        }
        if (other.CompareTag("cylinder2"))
        {
            if(top2 == 1)
            {
                source.PlayOneShot(source1);
            }
            //source.Play();
            trig = false;
            if (top2 == -1)
            {
                top2++;
                parent.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                d2[top2] = this.GetComponentInParent<BoxCollider>().size.x;
                s2[top2] = parent.transform.name;
                Debug.Log(d2[top2]+"added to stack "+this.GetComponentInParent<Transform>().name );
                this.GetComponentInParent<Leap.Unity.Interaction.InteractionBehaviour>().enabled = false;
                //source.PlayOneShot(source1);
            }
            else if (this.GetComponentInParent<BoxCollider>().size.x > d2[top2])
            {
                top2++;
                Debug.Log("invalid step");
                this.GetComponentInParent<Leap.Unity.Interaction.InteractionBehaviour>().enabled = false;
                parent.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                parent.transform.position = pos;
                source.PlayOneShot(source2);
            }
            else
            {
               // source.PlayOneShot(source1);
                top2++;
                parent.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                d2[top2] = this.GetComponentInParent<BoxCollider>().size.x;
                s2[top2] = parent.transform.name;
                Debug.Log("added to stack " + this.GetComponentInParent<Transform>().name);
                this.GetComponentInParent<Leap.Unity.Interaction.InteractionBehaviour>().enabled = false;
                
            }

        }
        if (other.CompareTag("cylinder3"))
        {
            trig = false;
            if (top3 == 1)
            {
                source.PlayOneShot(source1);
            }
            if (top3 == -1)
            {
                top3++;
                d3[top3] = this.GetComponentInParent<BoxCollider>().size.x;
                s3[top3] = parent.transform.name;
                parent.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                Debug.Log(d3[top3]+"  added to stack " + this.GetComponentInParent<Transform>().name);
                this.GetComponentInParent<Leap.Unity.Interaction.InteractionBehaviour>().enabled = false;
                //source.PlayOneShot(source1);
            }
            else if (this.GetComponentInParent<BoxCollider>().size.x > d3[top3])
            {
                top2++;
                Debug.Log("invalid step");
                parent.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                this.GetComponentInParent<Leap.Unity.Interaction.InteractionBehaviour>().enabled = false;
                parent.transform.position = pos;
                source.PlayOneShot(source2);


            }
            else
            {
                top3++;
                parent.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                d3[top3] = this.GetComponentInParent<BoxCollider>().size.x;
                s3[top3] = parent.transform.name;
                Debug.Log("added to stack " + this.GetComponentInParent<Transform>().name);
                this.GetComponentInParent<Leap.Unity.Interaction.InteractionBehaviour>().enabled = false;
                //source.PlayOneShot(source1);
            }

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
            Debug.Log(pos+"exited from"+other.name);
            if(top1>-1)
            {
                top1--;
            }
            trig = true;
            
        }
        if (other.CompareTag("cylinder2"))
        {
            pos.x = -97.3f;
            pos.y = 589.9f;
            pos.z = 183.5f;
            Debug.Log(pos + "exited from" + other.name);
            if (top2 > -1)
            {
                top2--;
            }
            trig = true;

        }
        if (other.CompareTag("cylinder3"))
        {
            pos.x = -97.5f;
            pos.y = 589.9f;
            pos.z = 183.5f;
            Debug.Log(pos + "exited from" + other.name);
            if (top3 > -1)
            {
                top3--;
            }
            trig = true;

        }
    }


}
