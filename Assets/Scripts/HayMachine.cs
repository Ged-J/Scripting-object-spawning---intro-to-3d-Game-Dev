using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachine : MonoBehaviour
{

    public float movementSpeed;
    public float horizontalBoundary = 22f;
    public GameObject hayBalePrefab;
    public Transform haySpawnpoint;
    public float shootInterval; //The  smallest amount of time between shots.
    private float shootTimer; //keep track whether the machine can shoot or not.


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        updateMovement();
        updateShooting();

    }

    private void updateShooting()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space))
        {

            shootTimer = shootInterval;
            ShootHay();

        }
    }

    private void updateMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");//1
        if(horizontalInput<0 && transform.position.x > -horizontalBoundary) //2
        {
            transform.Translate(transform.right * -movementSpeed * Time.deltaTime);
        }
        else if (horizontalInput>0 && transform.position.x < horizontalBoundary)//3
        {
            transform.Translate(transform.right* movementSpeed * Time.deltaTime);
        }
    }

    private void ShootHay()
    {
        Instantiate(hayBalePrefab, haySpawnpoint.position, Quaternion.identity);
    }

}
