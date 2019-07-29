using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookFollow : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
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
            Looking();
        }
    }


    public void Looking()
    {
        // head.LookAt(target.position);
        // head.rotation = head.rotation * Quaternion.Euler(offset);
        Quaternion lookRotation = Quaternion.LookRotation(target.position - head.position);
        // Debug.Log(target.position + "dfsdfds" + lookRotation);
        head.rotation = Quaternion.Lerp(head.rotation, lookRotation, Time.deltaTime * speed);
        // Debug.Log(head.rotation);
        // 애니메이션을 켜고 하면 안됨. 왜일까? 애니메이션 켜고 래이트 업데이트로 하면 또 살짝 됨.

    }
}