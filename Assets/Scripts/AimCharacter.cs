using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCharacter : MonoBehaviour
{
    public GameObject ToAim;

    public GameObject Projectile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 target = ToAim.transform.position;

        Vector2 myPos = transform.position;

        target.x = target.x - myPos.x;
        target.y = target.y - myPos.y;

        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));


        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject obj = Instantiate(Projectile);
            obj.transform.position = transform.position + new Vector3(target.x, target.y).normalized * 0.5f;
            obj.GetComponent<ProjectileController>().direction = target.normalized;
        }

    }
}
