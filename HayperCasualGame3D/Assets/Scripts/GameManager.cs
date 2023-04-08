using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject losePanel;
    public int Score;
    public Text scoreText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LevelEnd()
    {
        losePanel.SetActive(true);
        scoreText.text = " Toplam Puan " + Score;
    }

    public void StartApp()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitApp()
    {
        Application.Quit();
    }
}
