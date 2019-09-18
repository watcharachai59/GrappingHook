using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ScriptGrappingHook : MonoBehaviour
{
    
    public Camera cam;
    public RaycastHit hit;

    public LayerMask cullingmask;
    public int Maxdistance;

    public bool Isflying;
    public Vector3 loc;

    public float speed = 10;
    public Transform hand;

    public FirstPersonController FPC;
    public LineRenderer LR;

    Rigidbody rb;
    

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(ScriptCheck.checkIsgroud)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                GetComponent<CharacterController>().Move(rb.transform.forward * 10f);
            }
        }
        

            
        if (Input.GetKey(KeyCode.F))
        {
            Findspot();
        }
            

        if (Isflying)
        {
            Flying();
        }
            

        if(Input.GetKey(KeyCode.Q) && Isflying)
        {
            Isflying = false;
            FPC.CanMove = true;
            LR.enabled = false;
        }
    }

    public void Findspot()
    {
        if(Physics.Raycast(cam.transform.position , cam.transform.forward, out hit ,Maxdistance , cullingmask))
        {
            Isflying = true;
            loc = hit.point;
            FPC.CanMove = false;
            LR.enabled = true;
            LR.SetPosition(1, loc);
            
        }
    }

    public void Flying()
    {
        
        transform.position = Vector3.Lerp(transform.position, loc, speed * Time.deltaTime / Vector3.Distance(transform.position, loc));
        LR.SetPosition(0, hand.position);

        if(Vector3.Distance(transform.position, loc) < 0.5f)
        {
            Isflying = false;
            FPC.CanMove = true;
            LR.enabled = false;
            
        }


        
       // GetComponent<CharacterController>().Move(transform.forward * Time.fixedDeltaTime);

       // print("Flying @" + Time.time);
    }


}
