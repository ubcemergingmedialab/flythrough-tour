using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m2ConsoleTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Log(string msg) {
        Debug.Log(gameObject.name + ": " + msg);
    }
}
