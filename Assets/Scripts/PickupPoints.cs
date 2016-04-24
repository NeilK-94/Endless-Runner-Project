using UnityEngine;
using System.Collections;

public class PickupPoints : MonoBehaviour {

    public int scoreToGive; //  value coin will give to player/score

    private ScoreManager theScoreManager;

    private AudioSource coinSound;

	// Use this for initialization
	void Start () {
        theScoreManager = FindObjectOfType<ScoreManager>();
        coinSound = GameObject.Find("Coin (1)").GetComponent<AudioSource>();    //  find coin sound
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            theScoreManager.AddScore(scoreToGive);  //  add score to give 
            gameObject.SetActive(false);    //  deactivate coin after hitting it

            if (coinSound.isPlaying)    //  so if we hit more than one coin it sounds much better
            {
                coinSound.Stop();
                coinSound.Play();
            }
            else
            {
                coinSound.Play();
            }
            coinSound.Play();
        }

    }
}
