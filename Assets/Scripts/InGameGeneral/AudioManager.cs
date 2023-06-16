using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip cutEmptySound;
    public AudioClip cutSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCutSound()
    {
        //�ʍs�l�j��Ɠ��������Ȃ�΃h�D�N�V��炷
        if (GameManager.destroyEnemy != null && GameManager.posDistance > 1.0f)
            audioSource.PlayOneShot(cutSound);
        else
            audioSource.PlayOneShot(cutEmptySound);
    }
}
