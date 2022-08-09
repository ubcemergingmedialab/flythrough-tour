using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class m2ToolTip : MonoBehaviour
{
    // Ray ray;
    // RaycastHit hit;

    // void Start()
    // {

    // }
     
    // void Update()
    // {
    //     ray = Camera.current.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
    //     if(Physics.Raycast(ray, out hit))
    //     {
    //         print (hit.collider.name);
    //     }
    // }

    Camera mainCam {get {return Camera.main.GetComponent<Camera>();} }

    bool   mainCamFound {get {return mainCam != null;} }
    Ray ray {get {return mainCam.ScreenPointToRay(Input.mousePosition);} }
    RaycastHit hit;
    bool didHitSomething {get {return Physics.Raycast(ray, out hit);} }
    bool hitCollider {get {return hit.collider != null;} }

    void Update()
    {
        if(!mainCamFound)
        {
            Debug.LogWarning("Main Camera not found!");
            return;
        }

        if(didHitSomething && hitCollider)
        {
            Debug.Log("Hit - " + hit.collider.name);
        }
    }
}