using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scissrot : MonoBehaviour
{
    
    public bool set=false;
    Vector3 pos;
    Vector3 par,sap;
    public GameObject scissor;
    public GameObject blade;
    public GameObject downH;
    public GameObject parent;
    public GameObject same;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        pos = downH.transform.rotation.eulerAngles;
        par = parent.transform.rotation.eulerAngles;
        sap = same.transform.rotation.eulerAngles;


    }
    public void OnActivate()
    {
        if (set)
        {
            Debug.Log("activated");
            downH.transform.rotation = Quaternion.Euler(par);
            //blade.GetComponent<BoxCollider>().enabled = true;
            blade.GetComponent<Ontouch>().opt = false;
         
        }

        
      
    }
    public void OndeActivate()
    {
        if (set)
        {
            Debug.Log("deactivated");
            downH.transform.rotation = Quaternion.Euler(sap);
            //blade.GetComponent<BoxCollider>().enabled = true;
            if (scissor.GetComponent<attachScissor>().onceGrasped)
            {
                blade.GetComponent<Ontouch>().opt = true;
            }


        }
        

    }

}
