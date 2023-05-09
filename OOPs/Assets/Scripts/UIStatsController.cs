using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIStatsController : MonoBehaviour
{
	public TextMeshProUGUI enemiesCountText;
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI lifeText;

	private int enemiesKilled = 0;
	private int score = 0;
	//private int life;

	//private PlayerShip player;

	public bool isPlaying = false;

	void Start()
	{
		isPlaying = true;
    }

	public void SumEnemies() {
		enemiesKilled += 1;
		enemiesCountText.text = "Enemies Killed: " + enemiesKilled;
	}

	public void SumScore(int value)
	{
		score += value;
		scoreText.text = "Score: " + score;
	}

	public void SetLife(int value)
	{
		lifeText.text = "Life: " + value;
	}

	public void SetGameOver() {
		isPlaying = false;
        //go to some menu-scene
        //SceneManager.LoadScene(0-2);?
    }


}