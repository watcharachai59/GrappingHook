using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCheck : MonoBehaviour
{
    public static bool checkIsgroud;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        checkIsgroud = true;
       
    }
    void OnTriggerExit(Collider other)
    {
        checkIsgroud = false;
        
    }
}
