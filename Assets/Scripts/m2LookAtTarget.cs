using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m2LookAtTarget : MonoBehaviour
{

    public Transform target;
    public float turnRate = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        // Rotate the camera every frame so it keeps looking at the target
        transform.LookAt(target);

        // Same as above, but setting the worldUp parameter to Vector3.left in this example turns the camera on its side
        //transform.LookAt(target, Vector3.left);

        // transform.rotation = Quaternion.RotateTowards (
        // transform.rotation,
        // Quaternion.LookRotation( (transform.position + target.position ) * -1),
        // Time.deltaTime * turnRate );

    }
}