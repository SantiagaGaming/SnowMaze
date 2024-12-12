using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public static SoundPlayer Instance;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _lose, _win, _dmg;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        
    }
    private SoundPlayer(){}

    public void PlayDamageSound() => _audioSource.PlayOneShot(_dmg);

    public void PlayWinSound() => _audioSource.PlayOneShot(_win);

    public void PlayLoseSound() => _audioSource.PlayOneShot(_lose);

}
