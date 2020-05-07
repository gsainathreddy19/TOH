using Leap;
using Leap.Unity;
using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attachScissor : MonoBehaviour
{
    public string scissrot;
    public GameObject han;
    public GameObject scissor;
    public GameObject scissor1,scissor2;
    //public Rigidbody rigidbody;
    Vector3 scissorOriginalPos;
    Quaternion scissorOriginalRotation;
    LeapProvider provider;
    private InteractionBehaviour _intObj;

    public bool onceGrasped = false;
   

    // Start is called before the first frame update
    void Start()
    {
        _intObj = GetComponent<InteractionBehaviour>();
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;
        scissorOriginalPos = scissor.transform.position;
        scissorOriginalRotation.x = 0;
        scissorOriginalRotation.y = 0;
        scissorOriginalRotation.z = 0;
        scissorOriginalRotation.w = 1;
        //Debug.Log(scissorOriginalRotation);
    }

    // Update is called once per frame
    void Update()
    {
        //Frame frame = provider.CurrentFrame;
        //Hand hand = frame.Hands[0];

        /*if(scissor.GetComponent<BoxCollider>().enabled == true)
        {
            
        }*/
        if (scissor.transform.position.y <= 589.89f)
        {
            scissor.GetComponent<BoxCollider>().enabled = true;
        }

            if (scissor.transform.position.y <= 588.969f)
        {
            //Debug.Log("Scissor fell down");
            scissor.transform.position = scissorOriginalPos;
        }

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

            han.GetComponent<scissrot>().set = true;
            onceGrasped = true;
            scissor.GetComponent<BoxCollider>().enabled = false;

            //Destroy(scissor.GetComponent<InteractionBehaviour>());
            //Destroy(rigidbody);

            //float glow = _intObj.closestHoveringControllerDistance.Map(0F, 0.2F, 1F, 0.0F);
            //targetColor = Color.Lerp(defaultColor, hoverColor, glow);

            Frame frame = provider.CurrentFrame;
            Hand hand = frame.Hands[0];
            // Debug.Log("Position : "+ hand.PalmPosition +"Rotation : "+hand.Rotation);
            Vector3 temp;
            temp.x = hand.PalmPosition.x ;
            temp.y = hand.PalmPosition.y ;
            temp.z = hand.PalmPosition.z ;
            //  scissor.transform.position = temp;

            
            Quaternion q;
            q.x = hand.Rotation.x;
            q.y = hand.Rotation.y;
            q.z = hand.Rotation.z;
            q.w = hand.Rotation.w;
            

            /*
            Vector3 w = Quaternion.ToEulerAngles(q);
            // w.x = w.x * 57.2957795f + x_f;
            w.x = x_f;
            w.y = w.y * 57.2957795f + y_f;
            w.z = w.z * 57.2957795f + z_f;
            */

            Quaternion scissorUpdatedRotation = Quaternion.Inverse(scissorOriginalRotation) * q;
            if (hand.IsRight)
            {
                scissor.transform.position = temp;
                scissor2.transform.position = temp;
                scissor.transform.rotation = scissorUpdatedRotation;
                scissor1.transform.rotation = scissorUpdatedRotation;
                scissor2.transform.rotation = scissorUpdatedRotation;
            }
            //   Debug.Log(w);
           // Debug.Log("Scissors Original Rotation : " + scissorOriginalRotation + "\nScissors Updated Rotation : " + scissorUpdatedRotation + "\nHand Rotation : " + q);

        }
    }
}
