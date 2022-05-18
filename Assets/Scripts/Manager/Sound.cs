using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Sound : MonoBehaviour
{
    public string nameClip;
    public AudioClip clip;

    [Range(0f,1f)]
    public float volume;
    [Range (0.1f,3)]
    public float pitch;
}
