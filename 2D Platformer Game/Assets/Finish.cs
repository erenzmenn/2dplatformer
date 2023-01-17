using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;
    private bool courseCleared = false;
    // Start is called before the first frame update
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !courseCleared)
        {
            finishSound.Play();
            courseCleared = true;
            Invoke("ClearCourse" , 2f);
            
        }
    }

    private void ClearCourse()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
