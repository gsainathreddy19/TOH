

using Leap;
using Leap.Unity;
using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This simple script attach obj to hands of an InteractionBehaviour as
/// a function of its distance to the palm of the closest hand that is
/// hovering nearby.
/// </summary>
[AddComponentMenu("")]
[RequireComponent(typeof(InteractionBehaviour))]
public class simplechange : MonoBehaviour
{
    public GameObject paper,mediator;
    Vector3 paperOriginalPos;
    public bool onceGrasped = false;
    public float a, b, c;
    /*
    [Tooltip("If enabled, the object will attach when a hand is nearby.")]
    public bool useHover = true;

    [Tooltip("If enabled, the object will use its primaryHoverColor when the primary hover of an InteractionHand.")]
    public bool usePrimaryHover = false;
   

    [Header("InteractionBehaviour Colors")]
    public Color defaultColor = Color.Lerp(Color.black, Color.white, 0.1F);
    public Color suspendedColor = Color.red;
    public Color hoverColor = Color.Lerp(Color.black, Color.white, 0.7F);
    public Color primaryHoverColor = Color.Lerp(Color.black, Color.white, 0.8F);

    [Header("InteractionButton Colors")]
    [Tooltip("This color only applies if the object is an InteractionButton or InteractionSlider.")]
    public Color pressedColor = Color.white;

    private Material _material;
    */

    private InteractionBehaviour _intObj;

    LeapProvider provider;
    Quaternion qw;
    //public GameObject paper;

    void Start()
    {
        _intObj = GetComponent<InteractionBehaviour>();
        paperOriginalPos = paper.transform.position;
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;
        //  Renderer renderer = GetComponent<Renderer>();
        /* if (renderer == null)
         {
             renderer = GetComponentInChildren<Renderer>();
         }
         if (renderer != null)
         {
             _material = renderer.material;
         }*/
        qw.x = 0;
        qw.y = 0;
        qw.z = 0;
        qw.w = 1;
    }

    void Update()
    {
        if(!mediator.GetComponent<mediator>().set)
        {
            onceGrasped = false;
        }
        if (paper.transform.position.y <= 589.8f)
        {
            paper.GetComponent<BoxCollider>().enabled = true;
            paper.GetComponent<Leap.Unity.Interaction.InteractionBehaviour>().enabled = true;
        }
        if (paper.transform.position.y <= 588.969f)
        {
            paper.transform.position = paperOriginalPos;
        }

     //   if (_material != null)
      //  {

            // The target color for the Interaction object will be determined by various simple state checks.
//Color targetColor = defaultColor;

            // "Primary hover" is a special kind of hover state that an InteractionBehaviour can
            // only have if an InteractionHand's thumb, index, or middle finger is closer to it
            // than any other interaction object.
            
                // Of course, any number of objects can be hovered by any number of InteractionHands.
                // InteractionBehaviour provides an API for accessing various interaction-related
                // state information such as the closest hand that is hovering nearby, if the object
                // is hovered at all.
                if (_intObj.isGrasped || onceGrasped)
                {
                   
                        onceGrasped = true;
                   //paper.GetComponent<BoxCollider>().enabled = false;

//                    float glow = _intObj.closestHoveringControllerDistance.Map(0F, 0.2F, 1F, 0.0F);
                   // targetColor = Color.Lerp(defaultColor, hoverColor, glow);

                    Frame frame = provider.CurrentFrame;
                    Hand hand = frame.Hands[0];
                    // Debug.Log("Position : "+ hand.PalmPosition +"Rotation : "+hand.Rotation);
                    Vector3 temp;
                    temp.x = hand.PalmPosition.x+a;
                    temp.y = hand.PalmPosition.y+b;
                    temp.z = hand.PalmPosition.z+c;
                    
                    Quaternion q;
                    q.x = hand.Rotation.x;
                    q.y = hand.Rotation.y;
                    q.z = hand.Rotation.z;
                    q.w = hand.Rotation.w;
                    if (hand.IsLeft)
                    {
                        paper.transform.position = temp;
                        paper.transform.rotation = Quaternion.Inverse(qw) * q;
                    }
                    //   Debug.Log(w);
                    // Type or member is obsolete
                }
       
            }
  

           /* if (_intObj.isSuspended)
            {
                // If the object is held by only one hand and that holding hand stops tracking, the
                // object is "suspended." InteractionBehaviour provides suspension callbacks if you'd
                // like the object to, for example, disappear, when the object is suspended.
                // Alternatively you can check "isSuspended" at any time.
                targetColor = suspendedColor;
            }

            // We can also check the depressed-or-not-depressed state of InteractionButton objects
            // and assign them a unique color in that case.
            if (_intObj is InteractionButton && (_intObj as InteractionButton).isPressed)
            {
                targetColor = pressedColor;
            }

            // Lerp actual material color to the target color.
            _material.color = Color.Lerp(_material.color, targetColor, 30F * Time.deltaTime);*/
        }
    


