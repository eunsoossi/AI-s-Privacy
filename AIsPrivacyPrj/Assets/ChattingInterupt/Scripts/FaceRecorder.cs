using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor.Animations;
#endif

public class FaceRecorder : MonoBehaviour
{

    public AnimationClip clip;
    private GameObjectRecorder m_recoeder;
    public bool record = false;

    // Start is called before the first frame update
    void Start()
    {
        m_recoeder = new GameObjectRecorder(gameObject);
        
        m_recoeder.BindComponentsOfType<SkinnedMeshRenderer>(gameObject, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (clip == null)
        {
            return;
        }

        if (record)
        {
            m_recoeder.TakeSnapshot(Time.deltaTime);
        }

        else if (m_recoeder.isRecording)
        {
            m_recoeder.SaveToClip(clip);
            m_recoeder.ResetRecording();
        }
    }
}
