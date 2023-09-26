using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockback : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other){
        if (other.tag == "Enemy" && Input.GetKeyDown("a")){
            Rigidbody enemy_rb = other.GetComponent<Rigidbody>();
            enemy_rb.AddForce(2000, 0 , 0);
            StartCoroutine(stopPush(0.1f, enemy_rb));
            // Debug.Log(Time.time);

        }
    }

    IEnumerator stopPush(float secs, Rigidbody enemy_rb){
        yield return new WaitForSeconds(secs);
        enemy_rb.velocity = Vector3.zero;
    }
}
