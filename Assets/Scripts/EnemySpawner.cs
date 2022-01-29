using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Vector2 Size;

    public GameObject enemy; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 Limit = Size / 2;
            Vector2 positionToPlace = new Vector2(transform.position.x + Random.Range(Limit.x, -Limit.x),
                                                  transform.position.y + Random.Range(Limit.y, -Limit.y));
            enemy.transform.position = positionToPlace;
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(transform.position, Size);
    }
}
