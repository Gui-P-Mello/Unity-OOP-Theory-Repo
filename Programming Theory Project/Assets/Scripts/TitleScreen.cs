using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] GameObject titleScreen;
    public Animator transition;

    public float transitionTime = 1f;
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    IEnumerator LoadLevel(int levelIndex)
    { 
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        
        Debug.Log("Play!");

        SceneManager.LoadScene(levelIndex);
    }
   
}
