using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    [SerializeField] AudioSource _audio;
    // Start is called before the first frame update
    void Start()
    {
        _audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
