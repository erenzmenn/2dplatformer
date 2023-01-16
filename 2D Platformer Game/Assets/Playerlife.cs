using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerlife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anm;

    [SerializeField] private AudioSource deathSoundEffect;
    
    void Start()
    {
        anm = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        deathSoundEffect.Play();
        anm.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
