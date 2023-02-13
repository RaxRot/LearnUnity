using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets;

    [SerializeField] private float timeBetweenSpawn = 1.5f;

    private int _indexToSpawn;
    
    [SerializeField] private TextMeshProUGUI scoreText;
    private int _score;

    [SerializeField] private GameObject gameOverPanel;

    [HideInInspector] public bool isGameActive;

    [SerializeField] private GameObject startPanel;

    private void Start()
    {
        gameOverPanel.SetActive(false);
        UpdateScore(_score);
    }

    public void StartGame(int difficulty)
    {
        startPanel.SetActive(false);
        timeBetweenSpawn /= difficulty;
        isGameActive = true;
        StartCoroutine(nameof(_StartSpawnCo));
    }

    private IEnumerator _StartSpawnCo()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(timeBetweenSpawn);
        
            _indexToSpawn = Random.Range(0, targets.Count);
            Instantiate(targets[_indexToSpawn]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        scoreText.text = _score.ToString();
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
