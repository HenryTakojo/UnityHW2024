using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerSample : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioMixerSnapshot[] snapshots; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            float[] weights = new float[2];
            weights[0] = 1.0f;
            weights[1] = 0.0f;
            mixer.TransitionToSnapshots(snapshots, weights, 1.0f);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            float[] weights = new float[2];
            weights[0] = 0.0f;
            weights[1] = 1.0f;
            mixer.TransitionToSnapshots(snapshots, weights, 1.0f);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            
        }
    }
}
