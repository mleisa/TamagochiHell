using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public void YouDied()
    {
        SceneManager.LoadScene("GameOver");
    }


    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene("GG");
        }
          
    } 
}
        
