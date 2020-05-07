using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using Leap.Unity.Interaction;
public class lifting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cub;
    Vector3 initpos;
    Vector3 temp1;
    LeapProvider provider;
    private InteractionBehaviour _intObj;
    void Start()
    {
        initpos = cub.transform.position;
        _intObj = GetComponent<InteractionBehaviour>();
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;

    }

    // Update is called once per frame
    void Update()
    {
        Frame frame = provider.CurrentFrame;
        temp1 = cub.transform.position;
        /*if (frame.Hands[0]==null)
        {
            cub.transform.position = initpos;
            Debug.Log("sai");
            cub.GetComponentInParent<Leap.Unity.Interaction.InteractionBehaviour>().gameObject.transform.position = initpos;
           

        }*/
        try
        {
            cub.GetComponentInParent<Leap.Unity.Interaction.InteractionBehaviour>().enabled = true;
            Hand hand = frame.Hands[0];
            Debug.Log(hand);
        }
        catch(System.Exception e)
        {
            Debug.Log(e);
            cub.transform.position = temp1;
            cub.GetComponentInParent<Leap.Unity.Interaction.InteractionBehaviour>().enabled = false;
        }
       /* if (hand == null)
        {
            cub.transform.position = initpos;
            Debug.Log("sai");
            cub.GetComponentInParent<Leap.Unity.Interaction.InteractionBehaviour>().gameObject.transform.position = initpos;


        }
        else
        {
            cub.GetComponentInParent<Leap.Unity.Interaction.InteractionBehaviour>().enabled = true;
        }*/

        //Debug.Log(cub.transform.position);
        
        /*if (cub.transform.position.x > initpos.x + 0.4)
        {
            cub.transform.position = initpos;
        }
        if (cub.transform.position.x < initpos.x - 0.4)
        {
            cub.transform.position = initpos;
        }
        if (cub.transform.position.z < initpos.z - 0.4)
        {
            cub.transform.position = initpos;
        }
        if (cub.transform.position.z > initpos.z + 0.4)
        {
            cub.transform.position = initpos;
        }*/
        if (cub.transform.position.y < initpos.y - 0.1)
        {
            cub.transform.position = initpos;
            
        }
        
    }
}
