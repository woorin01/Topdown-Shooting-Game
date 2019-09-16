using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float speed;

    void Update()
    {
        LookAtCursor();
        Movement(); 
        Shoot();
        
    }

    private void LookAtCursor()
    {
        Vector3 cursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 v = (cursor - transform.position).normalized;
        transform.up = v;
    }

    //private void LookAtCursor()
    //{
    //    Vector3 c = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    Vector2 lookDir = c - transform.position;
    //    float a = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
    //    transform.rotation = Quaternion.Euler(0f, 0f, a);
    //}

    private void Movement()
    {
        float y = Input.GetAxisRaw("Vertical");
        float x = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(x, y) * Time.deltaTime * speed;
    }

    private void MovementToCursor()
    {
        float y = Input.GetAxisRaw("Vertical");
        float x = Input.GetAxisRaw("Horizontal");

        Vector3 temp = ((transform.up * y) + (transform.right * x)).normalized * speed;

        transform.position += temp * Time.deltaTime;
    }

    private void Shoot()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject temp = Instantiate(bullet, firePoint.position, firePoint.rotation);

            Destroy(temp, 6f);
        }
    }

}
