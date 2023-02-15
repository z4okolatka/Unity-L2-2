using System;
using UnityEngine;

public class unhook : MonoBehaviour
{
    private HingeJoint2D _joint;
    
    private void Start()
    {
        _joint = GetComponent<HingeJoint2D>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Destroy(_joint);
        }    
    }
}
