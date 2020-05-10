using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnLaser();
    }

    void SpawnLaser()
    {
        transform.Translate(new Vector3(0,8,0) * Time.deltaTime);

        if(transform.position.y >= 8f){
            if(transform.parent != null){
                Destroy(transform.parent.gameObject);
            }
            Destroy (gameObject);
        }
    }
}
