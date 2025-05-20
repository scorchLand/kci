using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEffect : MonoBehaviour
{
    public ParticleSystem particle;

    private void Awake()
    {
        particle.Stop();
    }
    public void Play()
    {
        particle.Play();
    }
}
