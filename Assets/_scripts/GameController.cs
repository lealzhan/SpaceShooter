using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait = 1;
    public float waveWait = 2;
    private Vector3 spawnPosition = Vector3.zero;
    private Quaternion spawnRotation;

    public Text scoreText;
    private int score;

    public Text gameOverText;
    private bool gameOver;

    public Text restartText;
    private bool restart;

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            if (gameOver) break;

            for (int i = 0; i < hazardCount; i++)
            {
                if (gameOver)
                {
                    restartText.text = "按【R】键重新开始游戏";
                    restart = true;
                    break;
                }
                spawnPosition.x = Random.Range(-spawnValues.x, spawnValues.x);
                spawnPosition.z = spawnValues.z;
                spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.text = "";
        gameOver = false;

        restartText.text = "";
        restart = false;

        score = 0;
        UpdateScore();

        StartCoroutine(SpawnWaves());
    }

    // Update is called once per frame
    void Update()
    {
        if(restart)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
               Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "得分：" + score;
    }

    public void GameOver()
    {
        gameOverText.text = "游戏结束";
        gameOver = true;
    }
}
