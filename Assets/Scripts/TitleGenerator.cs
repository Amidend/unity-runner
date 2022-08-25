using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleGenerator : MonoBehaviour
{
    
    public GameObject[] titlePrefabs;
    public GameObject[] backgroundPrefabs;

    [SerializeField] private Transform _player;
    private List<GameObject> _activeTiltles = new List<GameObject>();
    private List<GameObject> _activeBackground = new List<GameObject>(); 
    private float _spawnPosition = 0;
    private float _titleLength = 100;
    private int _startTitles = 3;
    void Start()
    {
        for(int i = 0; i < _startTitles; i++)
        {
            SpawnTitles(Random.Range(0,titlePrefabs.Length));
        }
    }
    void Update()
    {
        if (_player.position.z - 80 > _spawnPosition - (_startTitles * _titleLength))
        {
            SpawnTitles(Random.Range(0, titlePrefabs.Length));
            DeleteTitle();
        }
    }
    private void SpawnTitles(int tileindex)
    {
        GameObject newTitleCenter = Instantiate(titlePrefabs[tileindex],transform.forward* _spawnPosition,transform.rotation);
        GameObject newTitleRight = Instantiate(titlePrefabs[Random.Range(0, titlePrefabs.Length)], transform.forward * _spawnPosition + new Vector3(10f,0f,0f), transform.rotation);
        GameObject newTitleLeft = Instantiate(titlePrefabs[Random.Range(0, titlePrefabs.Length)], transform.forward * _spawnPosition + new Vector3(-10f, 0f, 0f), transform.rotation);
        _activeTiltles.Add(newTitleLeft);
        _activeTiltles.Add(newTitleRight);
        _activeTiltles.Add(newTitleCenter);
        _spawnPosition += _titleLength;
    }
    private void DeleteTitle()
    {
        for (int i = 0; i < 3; i++)
        {
            Destroy(_activeTiltles[0]);
            _activeTiltles.RemoveAt(0);
        }
    }
}
