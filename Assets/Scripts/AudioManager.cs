using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-----Audio Source-----")]
    [SerializeField] AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
