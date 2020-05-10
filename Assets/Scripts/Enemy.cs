using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (new Vector3(0,-2,0) * Time.deltaTime);

        if(transform.position.y <= -4){
            transform.position = new Vector3(Random.Range(-9.0f,9.0f),4,0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player")
        {
            //damage player
            Player player = other.transform.GetComponent<Player>();

            if (player!= null && player.ShieldState == true){

            }
            else if(player != null){
                player.Damage();
            }
            Destroy(this.gameObject);
        }

        if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
