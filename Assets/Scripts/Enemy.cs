using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Player _player;
    private Animator m_Animator;
    [SerializeField]
    private float _speed = -3.0f;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        if(_player == null)
        {
            Debug.LogError("Player is null");
        }
        m_Animator = GetComponent<Animator>();

        if(m_Animator == null)
        {
            Debug.LogError("The Animator is null");
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (new Vector3(0,_speed,0) * Time.deltaTime);

        if(transform.position.y <= -4){
            transform.position = new Vector3(Random.Range(-9.0f,9.0f),4,0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other){

        if(other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if(player!=null && player.ShieldState == true){
                _speed = 0f;
                m_Animator.SetTrigger("OnEnemyDeath");
                Destroy(this.gameObject,2.3f);
            }
            else if(player != null){
                player.Damage();
                _speed = 0f;
                m_Animator.SetTrigger("OnEnemyDeath");
                Destroy(this.gameObject,2.3f);
            }
        }

        if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            if(_player!=null){
                _player.AddScore();
            }
            m_Animator.SetTrigger("OnEnemyDeath");
            _speed = 0f;
            Destroy(this.gameObject,2.3f);

        }
    }
}
