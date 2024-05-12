using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
#if UNITY_ANDROID
using UnityEngine.Networking;
#endif

public class checkpath : MonoBehaviour
{
    // TODO :
    // create two methods , one for each platform and depends on the runtime 
    // call the button event based on the platform 
    //i.e infernce on andoid 
    
    void Start() { 
         string android_dir = "jar:file://" + Application.dataPath + "!/assets" + "/StreamingAsset/cpu";
        Debug.Log(android_dir);
        if (android_dir!=null)
        {
            Debug.Log("model probably exist");
        }
        else
        {
            Debug.Log("path is null");
        }
    }

    // Update is called once per frame
    void Update()
        {

        }




 } 



