using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnTetromino : MonoBehaviour
{
    private int score;
    public GameObject [] Tetrominoes;
    public GameObject NextTetrimino;
    public Text scoreText;
    public Text endGameText;
    private int currentLevelScore;

    public AudioSource source;
    public AudioClip endGameSound;

    // Start is called before the first frame update
    void Start()
    {
        NewTetromino();
        score = 0;
        currentLevelScore = 0;
        SetScoreText();
        FindObjectOfType<PieceGrabber>().GrabNextPiece();
    }

    // Update is called once per frame
    void update()
    {

    }

    private IEnumerator playEndGameSound()
    {
        Debug.Log("Entered BlockSound");
        source = GetComponent<AudioSource>();
        source.clip = endGameSound;
        source.Play();
        yield return new WaitForSeconds(source.clip.length);
    }

    public void checkLevelProgress()
    {
        if (currentLevelScore >= 1000)
        {
            FindObjectOfType<TetrisBlock>().IncreaseSpeed();
            endGameText.text = "Checklevel entered with: " + currentLevelScore.ToString();
            currentLevelScore = 0;
        }
    }

    public void NewTetromino()
    {
        NextTetrimino = Instantiate(Tetrominoes[Random.Range(0, Tetrominoes.Length)], transform.position, Quaternion.identity);
    }

    public GameObject GrabTetrimino()
    {
        GameObject liveTetrimino = NextTetrimino.gameObject;
        Destroy(NextTetrimino.gameObject);
        NewTetromino();
        return liveTetrimino.gameObject;
    }

    public void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void UpdateScore()
    {
        score += 100;
        currentLevelScore += 100;
        checkLevelProgress();
    }

    public void ShowEndGameScreen()
    {
        StartCoroutine(playEndGameSound());
        endGameText.text = "Thanks for playing!\n" +
            "Your final score was: " + score;
    }
}
