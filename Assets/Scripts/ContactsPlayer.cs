using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactsPlayer : MonoBehaviour
{
    public GameObject explosion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CreateNext"))
        {
            Stairs.instance.CreateNextStairsPart();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            MyEventManager.CallPlayerDead();            
        }            
        else if (other.gameObject.CompareTag("MovingOff"))
        {
            MyEventManager.CallPlayerDead();
        }
        else if (other.gameObject.CompareTag("Fall"))
        {            
            gameObject.GetComponent<PlayerGoDown>().enabled = true;
        }        
    }
}