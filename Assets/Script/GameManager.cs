using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    [SerializeField] Text DisplayScore;
    [SerializeField] Text DisplayMessage;
    [SerializeField] GameObject player;

    int Score = 0;
    bool winFlag = false;
    float waitToExit=4.0f;
    int winScore = 100;   
    public int _Score { get { return Score; } set { Score = value; } }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void UpdatePlayingScore(int _AddScore)
    {
        _Score += _AddScore;
        DisplayScore.text = $"Score : {_Score}";
    }
    public void Win(int score)
    {
        DisplayMessage.text = $"You Win\n{(int)waitToExit}";
        winFlag = true;
    }
    void WaitToExit() 
    {
        if (winFlag == true)
        {
            player.GetComponent<PlayerMove>().enabled = false;
            waitToExit -= Time.deltaTime;
            Debug.Log(waitToExit);
            if (waitToExit <= 0)
            {
                waitToExit = 3.0f;
                SceneManager.LoadScene("EnterTheGame");
            }

        }
        else 
        {
            return;
        }
    }
    private void Update()
    {
        if (_Score >= winScore)
        {
            Win(_Score);
        }
        WaitToExit();
    }
    //IEnumerator Win()
    //{
    //    //Countdown For 3 Seconds and back to main page
    //    int SecondToWait = 3;
    //    Closing = true;

    //    DisplayMessage.text = $"You Win!!\n{SecondToWait} left to OpeningPage";
    //    while (SecondToWait > 0)
    //    {
    //        yield return new WaitForSeconds(1f);
    //        SecondToWait -= 1;
    //        DisplayMessage.text = $"You Win!!\n{SecondToWait} left to OpeningPage";
    //    }
    //    BackToOpeningScene();
    //}
    void BackToOpeningScene()
    {
        SceneManager.LoadScene("EnterTheGame");
    }
    //public int ReturnPlayerPositionInList()
    //{
    //    //Return the closest item with its index in pool
    //    if (Player == null)
    //    {
    //        return -1;
    //    }
    //    Vector3 PlayerPosition = Player.transform.position;
    //    if (PlayerPosition.x > 10.5f || PlayerPosition.z > 10.5f)
    //    {
    //        return -1;
    //    }
    //    if (PlayerPosition.x < -0.5f || PlayerPosition.z < -0.5f)
    //    {
    //        return -1;
    //    }

    //    int x;
    //    int z;
    //    x = (int)PlayerPosition.x + ((PlayerPosition.x % 1f) > 0.5f ? 1 : 0);
    //    z = (int)PlayerPosition.z + ((PlayerPosition.z % 1f) > 0.5f ? 1 : 0);

    //    return x * 10 + z;
    //}
}
