using System;
using UnityEngine;

public class RopeUnhooker : MonoBehaviour
{
    [SerializeField] KeyCode Key;
    private HingeJoint2D _joint;
    
    private void Start()
    {
        _joint = GetComponent<HingeJoint2D>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(Key))
        {
            _joint.enabled = false;
        }    
    }
}
