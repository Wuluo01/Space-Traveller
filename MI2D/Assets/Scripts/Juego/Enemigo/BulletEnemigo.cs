using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemigo : MonoBehaviour
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

    void OnTriggerEnter2D(Collider2D other)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null && audioSource.clip != null)
        {
            // Crear un objeto temporal para reproducir el sonido
            GameObject tempAudio = new GameObject("TempAudio");
            tempAudio.transform.position = transform.position;
            AudioSource tempAudioSource = tempAudio.AddComponent<AudioSource>();
            tempAudioSource.clip = audioSource.clip;
            tempAudioSource.volume = audioSource.volume;  // Copiar el volumen del AudioSource original
            tempAudioSource.Play();

            // Destruir el objeto de audio temporal después de que el sonido termine
            Destroy(tempAudio, audioSource.clip.length);
        }

        // Destruir el proyectil inmediatamente
        Destroy(gameObject);
    }
}
