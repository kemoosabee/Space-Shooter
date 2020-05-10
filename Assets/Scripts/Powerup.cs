using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private Player player;
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private int powerupID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (new Vector3(0,-_speed,0) * Time.deltaTime);

        if(transform.position.y <= -4){
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            player = other.transform.GetComponent<Player>();
            if(player != null)
            {
                if(powerupID == 0){
                    player.ActiveTriple();
                }

                if(powerupID == 1){
                    player.ActiveSpeed();
                }
                if(powerupID == 2){
                    player.ActiveShield();
                }
            }
            Destroy(this.gameObject);
        }
    }
}
