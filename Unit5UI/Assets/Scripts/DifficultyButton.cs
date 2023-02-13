using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
     private Button _button;

     private GameManager _gameManager;

     [SerializeField] private int difficulty;

     private void Start()
     {
          _gameManager = FindObjectOfType<GameManager>();
          
          _button = GetComponent<Button>();
          _button.onClick.AddListener(SetDifficulty);
     }

     private void SetDifficulty()
     {
          _gameManager.StartGame(difficulty);
     }
}
