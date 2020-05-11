using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public or private variable
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.5f;
    [SerializeField]
    private float _nextFire = 0.0f;
    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManger;
    [SerializeField]
    private GameObject _tripleLaserPrefab;
    [SerializeField]
    private bool _isTripleActive = false;
    [SerializeField]
    private bool _isSpeedActive = false;
    [SerializeField]
    private bool _isShieldActive = false;
    public bool ShieldState = false;
    [SerializeField]
    private GameObject _shieldVisualizer;
    [SerializeField]
    private int _score = 0;

    // Start is called before the first frame update
    void Start()
    {
    // take the current position = new position (0,0,0)
        transform.position = new Vector3(0,0,0);
        _spawnManger = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>(); 
        _shieldVisualizer.SetActive(false);
    }

    void boundary()
    {

        transform.position = new Vector3(transform.position.x,Mathf.Clamp(transform.position.y,-4,4),0);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-9,9),transform.position.y,0);

    }

    void FireLaser()
    {
            if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire){

                if( _isTripleActive == true){
                    Instantiate(_tripleLaserPrefab,transform.position + new Vector3(-1.5f,1.0f,0),Quaternion.identity);
                }
                else{
                    _nextFire = Time.time + _fireRate;
                    Instantiate(_laserPrefab, transform.position + new Vector3(0,1.0f,0), Quaternion.identity);
                }
        }
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");

        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontalInput,verticalInput,0) * _speed * Time.deltaTime);

        FireLaser();

        boundary();
        Debug.Log(_lives);
    }

    public void Damage(){
        _lives -= 1;
        if(_lives < 1){
            Destroy(this.gameObject);
            _spawnManger.OnPlayerDeath();
        }
    }
    public void ActiveTriple(){
        _isTripleActive = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    public void ActiveSpeed(){
        _isSpeedActive = true;
        _speed = 10.0f;
        StartCoroutine(SpeedPowerDownRoutine());
    }

    public void ActiveShield(){
        _isShieldActive = true;
        ShieldState = true;
        _shieldVisualizer.SetActive(true);
        StartCoroutine(ShieldDownRoutine());
    }

    IEnumerator TripleShotPowerDownRoutine(){
        yield return new WaitForSeconds(5);
        _isTripleActive = false;
    }

    IEnumerator SpeedPowerDownRoutine(){
        yield return new WaitForSeconds(5);
        _isSpeedActive = false;
        _speed = 3.5f;
    }

    IEnumerator ShieldDownRoutine(){
        yield return new WaitForSeconds(5);
        _isShieldActive = false;
        _shieldVisualizer.SetActive(false);
        ShieldState = false;
    }

    public void AddScore(){
        _score += 10;
        Debug.Log("HIII");
    }
    public int GetScore(){
        return _score;
    }

    public int GetLives(){
        return _lives;
    }

}
