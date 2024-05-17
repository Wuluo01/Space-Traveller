using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : MonoBehaviour//para todos los comportamientos de la bala disparadas por el jugador
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
    void OnTriggerEnter2D(Collider2D other)//gestión de colisiones con los demás
    {
        if (other.gameObject.CompareTag("HealthItem"))
        {
            Vidas playerHealth = player.GetComponent<Vidas>();
            if (playerHealth != null)
            {
                playerHealth.health += 1;
            }
            Destroy(other.gameObject);
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
                GameObject tempAudio = new GameObject("TempAudio");
                tempAudio.transform.position = transform.position;
                AudioSource tempAudioSource = tempAudio.AddComponent<AudioSource>();
                tempAudioSource.clip = audios.clip;
                tempAudioSource.volume = audios.volume; 
                tempAudioSource.Play();
                Destroy(tempAudio, audios.clip.length);
            }
            Destroy(gameObject);
        }
        AudioSource audio = GetComponent<AudioSource>();
        if (audio != null && audio.clip != null)
        {
            GameObject tempAudio = new GameObject("TempAudio");
            tempAudio.transform.position = transform.position;
            AudioSource tempAudioSource = tempAudio.AddComponent<AudioSource>();
            tempAudioSource.clip = audio.clip;
            tempAudioSource.volume = audio.volume;
            tempAudioSource.Play();
            Destroy(tempAudio, audio.clip.length);
        }
        Destroy(gameObject);
    }    
}
