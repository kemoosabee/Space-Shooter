using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private bool _stopSpawning = false;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private GameObject _powerupContainer;
    [SerializeField]
    private GameObject _speedPrefab;
    [SerializeField]
    private GameObject _shieldPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnTriplePowerupRoutine());
        StartCoroutine(SpawnSpeedPowerRoutine());
        StartCoroutine(SpawnShieldPowerRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnEnemyRoutine()
    {
        while(_stopSpawning == false){
            GameObject newEnemy = Instantiate(_enemyPrefab,new Vector3(Random.Range(-9,9),4,0),Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5);
        }
    }

    IEnumerator SpawnTriplePowerupRoutine()
    {
        while(_stopSpawning == false){
            GameObject newPowerup = Instantiate(_tripleShotPrefab, new Vector3(Random.Range(-9,9),4,0),Quaternion.identity);
            newPowerup.transform.parent = _powerupContainer.transform;
            yield return new WaitForSeconds(Random.Range(6,8));
        }
    }

    IEnumerator SpawnSpeedPowerRoutine()
    {
        while(_stopSpawning == false){
            GameObject newPowerup = Instantiate(_speedPrefab, new Vector3(Random.Range(-9,9),4,0),Quaternion.identity);
            newPowerup.transform.parent = _powerupContainer.transform;
            yield return new WaitForSeconds(Random.Range(15,20));
        }
    }

    IEnumerator SpawnShieldPowerRoutine()
    {
        while(_stopSpawning == false){
            GameObject newPowerup = Instantiate(_shieldPrefab, new Vector3(Random.Range(-9,9),4,0),Quaternion.identity);
            newPowerup.transform.parent = _powerupContainer.transform;
            yield return new WaitForSeconds(Random.Range(15,20));
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }

    public void OnPlayerRestart()
    {
        _stopSpawning = false;
    }
}
