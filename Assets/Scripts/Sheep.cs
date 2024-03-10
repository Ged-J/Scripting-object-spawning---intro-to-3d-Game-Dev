using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{

    public float runSpeed;
    public float gotHayDestroyDelay; //delay in seconds before the sheep gets destroyed.
    private bool hitByHay; //gets set to true once the sheep was hit by hay.

    public float dropDestroyDelay; //Time in seconds before the sheep gets destroyed.
    private Collider myCollider; //reference to the sheeps collider
    private Rigidbody myRigidbody; //reference to the sheeps Rigidbody.


    // Start is called before the first frame update
    void Start()
    {
        
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward*runSpeed*Time.deltaTime);
    }

    private void HitByHay()
    {
        hitByHay = true;
        runSpeed = 0; //stop the sheep moving.
        Destroy(gameObject, gotHayDestroyDelay);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Hay")&& !hitByHay)
        {
            Destroy(other.gameObject);
            HitByHay();
        }
        else if(other.CompareTag("DropSheep"))
        {
            Drop();
        }
    }

    private void Drop()
    {
        myRigidbody.isKinematic = false; //gravity!
        myCollider.isTrigger = false; //sheep become a solid object
        Destroy(gameObject, dropDestroyDelay);
    }

}
