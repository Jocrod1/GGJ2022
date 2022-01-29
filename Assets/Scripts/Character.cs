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

    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        string typeinput = "";
        if (typeCharacter == TypeChar.second)
            typeinput = "2nd";
        Vector2 move = new Vector2(Input.GetAxisRaw(typeinput +"Horizontal"), Input.GetAxisRaw(typeinput + "Vertical"));

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
        Debug.Log(collision.tag);
        if (collision.tag == "Projectile")
        {
            Debug.Log("H I T");
            lives--;
        }
    }
}
