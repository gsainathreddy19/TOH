using Leap;
using Leap.Unity;
using Leap.Unity.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gluestickattach : MonoBehaviour
{
    public GameObject scissor;
    public Rigidbody rigidbody;
    Vector3 scissorOriginalPos;
    LeapProvider provider;
    private InteractionBehaviour _intObj;
    List<InteractionController> controllers;
    private HashSet<InteractionController> _contactingControllers = new HashSet<InteractionController>();
    public Action<InteractionController> OnPerControllerContactBegin;
    public bool onceGrasped = false;

    public float x_p, y_p, z_p;
    public float x_f, y_f, z_f;

    // Start is called before the first frame update
    void Start()
    {
        _intObj = GetComponent<InteractionBehaviour>();
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;
        scissorOriginalPos = scissor.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Frame frame = provider.CurrentFrame;
        //Hand hand = frame.Hands[0];

        /*if(scissor.GetComponent<BoxCollider>().enabled == true)
        {
            
        }*/
       

        if (_intObj.isGrasped || onceGrasped)
        {

            /*if (!_intObj.isHovered)
            {
                onceGrasped = false;
            }
            else
            {
                onceGrasped = true;
            }*/
            onceGrasped = true;
           // scissor.GetComponent<BoxCollider>().enabled = false;
           // Destroy(scissor.GetComponent<InteractionBehaviour>());
           // Destroy(rigidbody);

            //float glow = _intObj.closestHoveringControllerDistance.Map(0F, 0.2F, 1F, 0.0F);
            //targetColor = Color.Lerp(defaultColor, hoverColor, glow);

            Frame frame = provider.CurrentFrame;
            Hand hand = frame.Hands[0];
            // Debug.Log("Position : "+ hand.PalmPosition +"Rotation : "+hand.Rotation);
            Vector3 temp;
            temp.x = hand.PalmPosition.x + x_p;
            temp.y = hand.PalmPosition.y + y_p;
            temp.z = hand.PalmPosition.z + z_p;
           
            Quaternion q;
            q.x = hand.Rotation.x;
            q.y = hand.Rotation.y;
            q.z = hand.Rotation.z;
            q.w = hand.Rotation.w;

#pragma warning disable CS0618 // Type or member is obsolete
            Vector3 w = Quaternion.ToEulerAngles(q);
            w.x = w.x * 57.2957795f + x_f;
            w.y = w.y * 57.2957795f + y_f;
            w.z = w.z * 57.2957795f + z_f;
            if (hand.IsRight)
            {
                scissor.transform.rotation = Quaternion.Euler(w);
                scissor.transform.position = temp;
            }
            //   Debug.Log(w);
#pragma warning restore CS0618 // Type or member is obsolete

        }
    }
}
