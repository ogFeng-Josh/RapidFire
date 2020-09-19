using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster2 : MonoBehaviour
{
    #region collectable variables
    public int collectableTotal;
	public int collectableCollected = 0;
	public Text collectableTotalText;
	public Text collectableCollectedText;

    #endregion

    #region gameTimer
    public int countdownTime;
    public Text countdownDisplay;
    public GameObject winScreen;
    public bool objectiveCompleted = false;


    #endregion

    #region Player Variables

    public GameObject playerPrefab;
    public Transform respawnLocaiton;
    public bool playerIsDead;

    //CameraFollow camScript;

    public bool hasSecondChance;
    public GameObject secondChance;

    public GameObject loseScreen;

    public playerData pAlive;

    #endregion

    #region Spawn System

    public GameObject[] enemies;
    public Transform[] respawnPoints;

    private int rand;
    private int randPosition;

    public float startTimeBtwSpawns;
    private float timeBtwSpawns;



    #endregion

    #region Initialization methods

    //Here
    private void Start()
    {
        //Spawn Initialize
        timeBtwSpawns = startTimeBtwSpawns;
        StartCoroutine(countdowntoStart());
        CountTotalCupsAvailable();
        pAlive = GameObject.Find("_player(ver. 2)").GetComponent<playerData>();
    }

    private void Update()
    {
        //Spawn System Update
        spawnerMethod();

        if(collectableTotal == collectableCollected)
        {
            objectiveCompleted = true;
        }
    }

    #endregion

    #region Collectables Methods

    public void CountTotalCupsAvailable()
	{
		collectableTotal = GameObject.FindGameObjectsWithTag("Collectible").Length;
		collectableTotalText.text = collectableTotal.ToString();
	}

	public void CupCollected()
	{
		collectableCollected = collectableCollected +1;
		collectableCollectedText.text = collectableCollected.ToString();
	}

    #endregion

    #region Time System

    IEnumerator countdowntoStart()
    {

        while(countdownTime > 0)
        {
        countdownDisplay.text = countdownTime.ToString();

        yield return new WaitForSeconds(1f);

        countdownTime--;
        }

        if(objectiveCompleted == true)
        {
            Debug.Log("Won & survived");
            Time.timeScale = 0.0f;
            winScreen.SetActive(true);
        }
        else
        {
            Debug.Log("Loss but survived");
            Time.timeScale = 0.0f;
            loseScreen.SetActive(true);
        }
    }

    #endregion

    #region Spawn System Methods

    private void spawnerMethod()
    {
        if(timeBtwSpawns <= 0)
        {
            rand = Random.Range(0, enemies.Length);
            randPosition = Random.Range(0, respawnPoints.Length);
            Instantiate(enemies[rand], respawnPoints[randPosition].transform.position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }

    #endregion










}
