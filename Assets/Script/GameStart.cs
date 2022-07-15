using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(() => {
            OnBtnClick();
        });
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.anyKey)
        //{
        //    SceneManager.LoadScene("Game");
        //}
    }
    public void OnBtnClick() 
    {
        SceneManager.LoadScene("Game");
    }
}
