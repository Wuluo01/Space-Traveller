using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletEnemigo : MonoBehaviour//para el comportamiento de las balas de los enemigos
{
    public float speed;
    void Start()
    {
        Destroy(gameObject, 3f);
    }
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D other)//música al colisionar con algo
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null && audioSource.clip != null)
        {
            GameObject tempAudio = new GameObject("TempAudio");
            tempAudio.transform.position = transform.position;
            AudioSource tempAudioSource = tempAudio.AddComponent<AudioSource>();
            tempAudioSource.clip = audioSource.clip;
            tempAudioSource.volume = audioSource.volume;  
            tempAudioSource.Play();
            Destroy(tempAudio, audioSource.clip.length);
        }
        Destroy(gameObject);
    }
}
