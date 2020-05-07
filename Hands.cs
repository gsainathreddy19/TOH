using Leap;
using Leap.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    LeapProvider provider;
    public GameObject scissor;
    public float x_p, y_p, z_p;
    public float x_f, y_f, z_f;
    public bool ontoc = false;
    // Start is called before the first frame update
    void Start()
    {
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;

    }

    // Update is called once per frame
    void Update()
    {
        if (ontoc == true)
        {
            Frame frame = provider.CurrentFrame;
            Hand hand = frame.Hands[0];
            // Debug.Log("Position : "+ hand.PalmPosition +"Rotation : "+hand.Rotation);
            Vector3 temp;
            temp.x = hand.PalmPosition.x + x_p;
            temp.y = hand.PalmPosition.y + y_p;
            temp.z = hand.PalmPosition.z + z_p;
            scissor.transform.position = temp;
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

            scissor.transform.rotation = Quaternion.Euler(w);
            //   Debug.Log(w);
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "hold")
        {
            ontoc = true;
        }
    }

}