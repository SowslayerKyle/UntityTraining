using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject pointBall;
    List<GameObject> ballList = new List<GameObject>();
    int itemActive = 0;
    int itemActiveMax = 10;
    GameManager GM;


    private void Start()
    {
        GM = GameManager.Instance;
        for (int i=0;i<100; i++)
        {
            Vector3Int position = new Vector3Int(i % 10, 1, i / 10);
            GameObject gameObject = Instantiate(pointBall, position, Quaternion.identity);           
            ballList.Add(gameObject);
            gameObject.transform.SetParent(this.transform);
            gameObject.SetActive(false);
            gameObject.GetComponent<BallReact>().OP = this;
        }
        ActiveItem();

    }
    private void Update()
    {
        //_Timer = Time.deltaTime;
        //ActiveItem();
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Debug.Log(itemActive);
        }
        if (itemActive < 3) 
        {
            ActiveItem();
        }
    }
    public void ActiveItem() 
    {
        if (itemActive >= itemActiveMax)
        {
            return;
        }
        //int IndexCouldNotBeUsed = GM.ReturnPlayerPositionInList();
        while (itemActive < itemActiveMax)
        {
            int random = Random.Range(0, ballList.Count);            
            if ( !ballList[random].activeInHierarchy)
            {
                ballList[random].SetActive(true);
                itemActive ++;
            }
        }
 
    }
    public void GetBall() 
    {
        GM.UpdatePlayingScore(5);
        itemActive--;
    }
}
