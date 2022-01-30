using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Vector2 Size;

    public GameObject enemy;
    
    public GameObject Player;
    public GameObject Player2nd;


    public List<GameObject> Pj1EnemyList;
    public List<GameObject> Pj2EnemyList;


    public GameplayManager GM;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject item in Pj1EnemyList)
        {
            pj1Stack.Enqueue(item);
        }

        foreach (GameObject item in Pj2EnemyList)
        {
            pj2Stack.Enqueue(item);
        }
    }

    Queue<GameObject> pj1Stack = new Queue<GameObject>();
    Queue<GameObject> pj2Stack = new Queue<GameObject>();


    public void SpawnEnemy()
    {
        if(pj1Stack.Count < 1)
        {
            GM.ResetScene();
            return;
        }
        Vector2 Limit = Size / 2f;
        float rangeX = Random.Range(Limit.x, -Limit.x);
        float rangeY = Random.Range(Limit.y, -Limit.y);

        Vector2 positionToPlace = new Vector2(transform.position.x + rangeX,
                                              transform.position.y + rangeY);

        GameObject instObj1 = pj1Stack.Dequeue();
        instObj1.transform.position = positionToPlace;
        instObj1.SetActive(true);

        float rangeX2 = Random.Range(Limit.x, -Limit.x);
        float rangeY2 = Random.Range(Limit.y, -Limit.y);

        Vector2 positionToPlace2 = new Vector2(transform.position.x + rangeX2,
                                              transform.position.y + rangeY2);

        GameObject instObj2 = pj2Stack.Dequeue();
        instObj2.transform.position = positionToPlace2;
        instObj2.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    SpawnEnemy();
        //}
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(transform.position, Size);
    }
}
