using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public Rigidbody2D player;
    public float knockback = 10f;

    private float startTime;
    public float shotDelay = 0.2f;

    public int magazineSize = 6;
    private int currentBullets;
    private float reloadTimer;
    public float reloadTime = 2f;

    [SerializeField] private Sprite[] ammo;
    public Image ammoDisplay;

    public AudioSource gunshot;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        currentBullets = magazineSize;
        ammoDisplay.sprite = ammo[0];
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Gun Shooting
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time - startTime >= shotDelay && currentBullets > 0)
        {
            Vector3 rot = transform.rotation.eulerAngles;
            rot = new Vector3(rot.x, rot.y, rot.z + 180);
            Quaternion spawnRotation = Quaternion.Euler(rot);
            //Spawn bullet
            Instantiate(bullet, spawnPoint.position, spawnRotation);
            //And give player knockback
            Vector3 direction = (this.transform.position - player.transform.position) * -1;
            direction = Vector3.Normalize(direction);

            anim.SetTrigger("Shoot");
            gunshot.Play();

            if (player.velocity.y < 0)
                player.velocity = new Vector2(player.velocity.x, 0);
            //player.velocity = new Vector2(player.velocity.x, player.velocity.y/2);

            player.AddForce(direction * knockback);
            //Activate cooldown between shots
            startTime = Time.time;
            currentBullets--;
            ammoDisplay.sprite = ammo[magazineSize - currentBullets];
            Debug.Log("Bullets loaded: " + currentBullets);
        }

        if((currentBullets == 0 || (Input.GetKeyDown(KeyCode.R) && currentBullets < magazineSize)) && reloadTimer == 0)
        {
            currentBullets = 0;
            ammoDisplay.sprite = ammo[6];
            reloadTimer = Time.time;
            Debug.Log("Reloading!");
        }
        else if(currentBullets == 0 && reloadTimer > 0)
        {
            if (Time.time - reloadTimer > reloadTime)
            {
                currentBullets = magazineSize;
                reloadTimer = 0;
                ammoDisplay.sprite = ammo[0];
                Debug.Log("Reloaded!");
            }
        }

    }
}
