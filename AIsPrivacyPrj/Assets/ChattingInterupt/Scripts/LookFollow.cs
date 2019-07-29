using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookFollow : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public Quaternion offsetQ;
    public bool lookOn;
    public float speed;

    Animator anim;
    Transform head;


    void Start()
    {
        anim = GetComponent<Animator>();
        head = anim.GetBoneTransform(HumanBodyBones.Head);
        lookOn = false;
    }

    void LateUpdate()
    {
        if (lookOn)
        {
            LookSmoothly();
        }
        else
        {
            return;
        }
    }


    public void LookSmoothly()
    {
        //head.LookAt(target.position);
        //head.rotation = head.rotation * Quaternion.Euler(offset);
        Quaternion lookRotation = Quaternion.LookRotation(target.position - head.position, Vector3.up);
        Quaternion correction = Quaternion.RotateTowards(offsetQ, lookRotation, Time.deltaTime * speed);
        Debug.Log(correction);
        head.rotation = head.rotation * correction * Quaternion.Euler(offset);
        
    }
}