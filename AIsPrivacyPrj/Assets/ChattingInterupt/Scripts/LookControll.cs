using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookControll : MonoBehaviour
{
    private Animator anim;
    public LookFollow lookFollow;
    bool eyeFollow = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        lookFollow = GetComponent<LookFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !anim.GetBool("look"))
        {
            anim.SetBool("look", true);
            if (anim.GetBool("look"))
            {
                lookFollow.lookOn = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) && anim.GetBool("look"))
        {
            anim.SetBool("look", false);
            if (!anim.GetBool("look"))
            {
                lookFollow.lookOn = false;
            }
        }
    }
}
