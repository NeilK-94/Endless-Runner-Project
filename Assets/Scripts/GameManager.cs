using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platformStartPoint; //  store where platform generator starts

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;

    private ScoreManager theScoreManager;

    public DeathMenu deathScreen;

	// Use this for initialization
	void Start () {
        platformStartPoint = platformGenerator.position;    //  startpoint is the generator position    
        playerStartPoint = thePlayer.transform.position;  //  same as above

        theScoreManager = FindObjectOfType<ScoreManager>(); //  find scoremanager in the scene
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Restart()
    {
        theScoreManager.scoreIncreasing = false;    //  score stop increasing when dead
        thePlayer.gameObject.SetActive(false);  //  player object becomes inactive once dead

        deathScreen.gameObject.SetActive(true); //  turn object on in game
        //StartCoroutine("RestartCoroutine");    //  coroutine runs independantly to rest of script. Allows for time delays (for delay after death)
    }

    public void Reset()
    {
        deathScreen.gameObject.SetActive(false); //  turn object off in game

        platformList = FindObjectsOfType<PlatformDestroyer>();  //  array of platformlist (all existing after death)
        for (int i = 0; i < platformList.Length; i++)   //  gets all platform in platform list
        {
            platformList[i].gameObject.SetActive(false);    //  sets platforms to false (inactive) one by one to remove them
        }

        thePlayer.transform.position = playerStartPoint;    //  basically opposite to what we said above
        platformGenerator.position = platformStartPoint;

        thePlayer.gameObject.SetActive(true);   //  activate him again

        theScoreManager.scoreCount = 0; //  set scre back to 0
        theScoreManager.scoreIncreasing = true;    //  take score again
    }
/*
    public IEnumerator RestartCoroutine()   //  coroutine runs independantly to rest of script. Allows for time delays (for delay after death)
    {
        theScoreManager.scoreIncreasing = false;    //  score stop increasing when dead
        thePlayer.gameObject.SetActive(false);  //  player object becomes inactive once dead
        yield return new WaitForSeconds(1.0f);  //  wait for one second

        platformList = FindObjectsOfType<PlatformDestroyer>();  //  array of platformlist (all existing after death)
        for (int i = 0; i < platformList.Length; i++)   //  gets all platform in platform list
        {
            platformList[i].gameObject.SetActive(false);    //  sets platforms to false (inactive) one by one to remove them
        }

        thePlayer.transform.position = playerStartPoint;    //  basically opposite to what we said above
        platformGenerator.position = platformStartPoint;

        thePlayer.gameObject.SetActive(true);   //  activate him again

        theScoreManager.scoreCount = 0; //  set scre back to 0
        theScoreManager.scoreIncreasing = true;    //  take score again
    }

 */
}
