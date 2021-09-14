using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneLoader : MonoBehaviour
{
    private float transitionTime = 1f;

    public Animator transition;
    public static SceneLoader Instance { get; private set; }

    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadTitleScreen()
    {
        StartCoroutine(CountToLoad());
    }

    IEnumerator CountToLoad()
    {
        transition.SetTrigger("Start");

        //Debug.Log("Transition triggered!");

        yield return new WaitForSeconds(transitionTime);

        Debug.Log("Play!");

        SceneManager.LoadScene(0);
        //SceneManager.LoadScene(levelIndex);
    }
}
