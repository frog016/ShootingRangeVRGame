using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fire : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 50f;

    public GameObject bulletPrefab;

    public Transform spawnBullet;

    public static event Action pistolFire;

    public void FireActivated()
    {
        GetComponent<AudioSource>().Play();
        GameObject createBullet = Instantiate(bulletPrefab, spawnBullet.position, spawnBullet.rotation);
        createBullet.GetComponent<Rigidbody>().velocity = speed * spawnBullet.forward;
        Destroy(spawnBullet, 5f);
        pistolFire?.Invoke();
    }
}
