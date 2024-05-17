using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public GameObject player; 
    public GameObject HyperExplosion;

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
        if (other.gameObject.CompareTag("HealthItem"))
        {
            // Recuperar vida del jugador
            Vidas playerHealth = player.GetComponent<Vidas>();
            if (playerHealth != null)
            {
                playerHealth.health += 1;
            }

            Destroy(other.gameObject);

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
        else if (other.gameObject.CompareTag("Bomb"))
        {
            Instantiate(HyperExplosion, other.transform.position, other.transform.rotation);
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
            GameObject[] bullets = GameObject.FindGameObjectsWithTag("BulletEnemy");
            foreach (GameObject bullet in bullets)
            {
                Destroy(bullet);
            }
            Destroy(other.gameObject);
            AudioSource audios = GetComponent<AudioSource>();
            if (audios != null && audios.clip != null)
            {
                // Crear un objeto temporal para reproducir el sonido
                GameObject tempAudio = new GameObject("TempAudio");
                tempAudio.transform.position = transform.position;
                AudioSource tempAudioSource = tempAudio.AddComponent<AudioSource>();
                tempAudioSource.clip = audios.clip;
                tempAudioSource.volume = audios.volume;  // Copiar el volumen del AudioSource original
                tempAudioSource.Play();

                // Destruir el objeto de audio temporal después de que el sonido termine
                Destroy(tempAudio, audios.clip.length);
            }

            // Destruir el proyectil inmediatamente
            Destroy(gameObject);
        }
        AudioSource audio = GetComponent<AudioSource>();
        if (audio != null && audio.clip != null)
        {
            // Crear un objeto temporal para reproducir el sonido
            GameObject tempAudio = new GameObject("TempAudio");
            tempAudio.transform.position = transform.position;
            AudioSource tempAudioSource = tempAudio.AddComponent<AudioSource>();
            tempAudioSource.clip = audio.clip;
            tempAudioSource.volume = audio.volume;  // Copiar el volumen del AudioSource original
            tempAudioSource.Play();

            // Destruir el objeto de audio temporal después de que el sonido termine
            Destroy(tempAudio, audio.clip.length);
        }

        // Destruir el proyectil inmediatamente
        Destroy(gameObject);
    }    
}
