using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public Text highScoreText;

    public float scoreCount;
    public float highScoreCount;

    public float pointsPerSec;

    public bool scoreIncreasing;

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("HighScore"))  //  used to keep highscore after quitting
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (scoreIncreasing)    //  stops scorinhg when dead
        {
            scoreCount += pointsPerSec * Time.deltaTime;    //  time its taken from each frame of animation to the other one

        }

        if (scoreCount > highScoreCount) //  sets highscore count every time
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreCount);  //  keeps high score after quitting
        }

        scoreText.text = "score: " + Mathf.Round (scoreCount);    //  print scorecount to the nearest whole number
        highScoreText.text = "High Score: " + Mathf.Round (highScoreCount);    //  print highScoreCount	to the nearest whole number
    }

    public void AddScore(int pointsToAdd)   //  used for adding extra points for coinsx distance etc
    {
        scoreCount += pointsToAdd;
    }
}
