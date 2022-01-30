using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TypeShooting
{
    linear,
    circular,
}
public class AimCharacter : MonoBehaviour
{
    public GameObject ToAim;

    public bool Aim2Target = true;

    public GameObject Projectile;

    public float projectileSpeed = 5;

    public int burstCount = 1;

    public float RateOfFire = 0.3f;

    public TypeShooting shooting = TypeShooting.linear;

    [Range(10, 350)]
    public float fieldOfShoooting = 30;

    [Range(2, 10)]
    public int HowManyLines = 2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 target = Aim2Target ? ToAim.transform.position :  transform.position + Vector3.up;


        if (Aim2Target)
        {
            Vector2 myPos = transform.position;

            target.x = target.x - myPos.x;
            target.y = target.y - myPos.y;

            float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        }
        


        if (Input.GetKeyDown(KeyCode.X))
        {
            Shoot();
        }

    }

    public void DestroyThis()
    {
        Destroy(transform.parent.gameObject);
    }

    public void Shoot()
    {
        if (burstCount > 1)
        {
            StartCoroutine(FireBurst());
        }
        else
        {
            Fire();
        }
    }

    IEnumerator FireBurst()
    {
        for (int i = 0; i < burstCount; i++)
        {
            Fire();

            yield return new WaitForSeconds(RateOfFire);
        }
    }

    public void Fire()
    {
        float rotationAngle = transform.eulerAngles.z + 90;

        if (shooting == TypeShooting.linear)
        {
            Vector3 LineNormalized = getAngle2normal(rotationAngle);
            GameObject obj = Instantiate(Projectile);
            obj.transform.position = transform.position + LineNormalized * 0.5f;
            obj.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
            ProjectileController ProjCrl = obj.GetComponent<ProjectileController>();
            ProjCrl.direction = LineNormalized;
            ProjCrl.speed = projectileSpeed;
        }
        else if (shooting == TypeShooting.circular)
        {

            float midFOS = fieldOfShoooting / 2;

            Gizmos.color = Color.cyan;

            float linesAngle = fieldOfShoooting / (float)(HowManyLines - 1);
            for (int i = 0; i < HowManyLines; i++)
            {
                Vector3 LineNormalized = getAngle2normal(rotationAngle + midFOS - linesAngle * i);
                GameObject obj = Instantiate(Projectile);
                obj.transform.position = transform.position + LineNormalized * 0.5f;
                obj.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
                ProjectileController ProjCrl = obj.GetComponent<ProjectileController>();
                ProjCrl.direction = LineNormalized;
                ProjCrl.speed = projectileSpeed;                
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;


        float rotationAngle = transform.eulerAngles.z + 90;

        Gizmos.DrawLine(transform.position, transform.position + getAngle2normal(rotationAngle) * 10);

        if (shooting == TypeShooting.circular)
        {
            float midFOS = fieldOfShoooting / 2;
            Gizmos.DrawLine(transform.position, transform.position + getAngle2normal(rotationAngle - midFOS) * 10);
            Gizmos.DrawLine(transform.position, transform.position + getAngle2normal(rotationAngle + midFOS) * 10);

            Gizmos.color = Color.cyan;

            float linesAngle = fieldOfShoooting / (float)(HowManyLines - 1);
            for (int i = 0; i < HowManyLines; i++)
            {
                Gizmos.DrawLine(transform.position, transform.position + getAngle2normal(rotationAngle + midFOS - linesAngle * i) * 10);
            }


        }
    }

    Vector3 getAngle2normal(float angle)
    {
        float radians = angle * Mathf.Deg2Rad;

        float x = Mathf.Cos(radians);
        float y = Mathf.Sin(radians);
        return new Vector3(x, y);
    }
}
