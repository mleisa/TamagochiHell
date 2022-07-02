using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("nein");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("HALLO");
            SceneManager.LoadScene("GG");
        }
          
    } 
}
        
