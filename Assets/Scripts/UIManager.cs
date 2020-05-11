using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Image _liveImg;
    [SerializeField]
    private Sprite[] _liveSprite;
    [SerializeField]
    private Text _gameOver;
    [SerializeField]
    private Text _restart;
    [SerializeField]
    private Player player;
    [SerializeField]
    private GameManager _gm;
    [SerializeField]
    private SpawnManager _spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        _gameOver.text = "";
        _scoreText.text = "Score: ";
        _restart.text ="";
        player = GameObject.Find("Player").GetComponent<Player>();
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = "Score: "+ player.GetScore();
        UpdateLives();
    }

    void UpdateLives()
    {
        _liveImg.sprite = _liveSprite[player.GetLives()];
        if(player.GetLives() == 0){
            StartCoroutine(GameOverFlickerRoutine());
            _restart.text = "Press the 'R' key to restart the level";
            _gm.GameOver();
        }
    }


    IEnumerator GameOverFlickerRoutine()
    {
        while(true){
            _gameOver.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            _gameOver.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
