using UnityEngine;
using System.Collections;

public class PickupPoints : MonoBehaviour {

    public int scoreToGive; //  value coin will give to player/score

    private ScoreManager theScoreManager;

	// Use this for initialization
	void Start () {
        theScoreManager = FindObjectOfType<ScoreManager>();
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
        }

    }
}
