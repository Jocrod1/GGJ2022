using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TypeChar
{
    first,
    second,
}

public class Character : MonoBehaviour
{
    public float MovementSpeed = 1;

    public TypeChar typeCharacter = TypeChar.first;

    public int lives;

    public GameObject spawnPoint;

    public bool dead = false;

    public GameplayManager GM;

    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
    }

    public float angle;
    public float Smoothing = 3; 

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GM.InGame)
            return;
        string typeinput = "";
        if (typeCharacter == TypeChar.second)
            typeinput = "2nd";
        Vector2 move = new Vector2(Input.GetAxisRaw(typeinput +"Horizontal"), Input.GetAxisRaw(typeinput + "Vertical"));

        if(move.x != 0 || move.y != 0)
        {
            angle = Mathf.Atan2(move.normalized.y, move.normalized.x) * Mathf.Rad2Deg;

        }

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle - 90)), Smoothing * Time.deltaTime);



        Vector3 movement = new Vector3(move.x * MovementSpeed * Time.deltaTime, move.y * MovementSpeed * Time.deltaTime, 0);

        Vector3 ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));

        // Debug.Log(ScreenBounds);

        Vector3 newpos = transform.position + movement;

        BoxCollider2D bCl2d = GetComponent<BoxCollider2D>();

        newpos.x = Mathf.Clamp(newpos.x, -ScreenBounds.x + (bCl2d.size.x / 2), ScreenBounds.x - (bCl2d.size.x / 2));
        newpos.y = Mathf.Clamp(newpos.y, -ScreenBounds.y + (bCl2d.size.y / 2), ScreenBounds.y - (bCl2d.size.y / 2));


        transform.position = newpos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GM.InGame)
            return;
        Debug.Log(collision.tag);
        if (collision.tag == "Projectile")
        {
            Debug.Log("H I T: " + transform.name);
            lives--;

            if (lives > 0)
            {
                gameObject.transform.position = spawnPoint.transform.position;
            }
            else
            {
                GM.ResetScene();
            }
        }
    }
}
