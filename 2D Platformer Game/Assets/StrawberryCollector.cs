using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrawberryCollector : MonoBehaviour
{
    private int strawberries = 0;

    [SerializeField] private Text sbText;
    [SerializeField] private AudioSource collectionSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Strawberry"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            strawberries++;
            sbText.text = "Strawberries:" + strawberries;

        }
    }
    
    
     



}