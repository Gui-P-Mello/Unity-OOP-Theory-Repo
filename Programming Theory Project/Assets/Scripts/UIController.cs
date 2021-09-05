using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;
    Enemy enemy;
    public static UIController Instance { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        enemy = RangedEnemy.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}
