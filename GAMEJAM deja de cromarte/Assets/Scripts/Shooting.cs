using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject proyectilePrefab;
    public AudioClip shootSound;
    private AudioSource audioSource;

    public float bulletForce = 20f;
    float LastShoot;

    Vector2 mousePos;
    public Camera cam;
    public Rigidbody2D rb;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > LastShoot + 1.0f)
        {
            Shoot();
            LastShoot = Time.time;
        }
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    void Shoot()
    {
        GameObject proyectile = Instantiate(proyectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = proyectile.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(shootSound);

    }
}
