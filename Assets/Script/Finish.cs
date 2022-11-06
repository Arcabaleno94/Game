using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public ParticleSystem particleFinish;
    public LevelController level;


  
    private void ReloadFinish()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // ReloadFinish();
            LevelController.instance.GameWin();
            LevelController.instance.LevelIndex++;
            particleFinish.Play();
        }
    }

}
