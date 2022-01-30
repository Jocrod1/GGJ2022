using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public Vector3 direction;
    private Vector3 uniDirection;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        uniDirection = direction.normalized;

        gameObject.transform.Translate(uniDirection * speed * Time.deltaTime);

        //if (gameObject.transform.position.y < -10)
        //{
        //    Destroy(gameObject);
        //}

        //if (gameObject.transform.position.y > ScreenBounds.y)
        //{
        //    Destroy(gameObject);
        //}
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
