using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleGenerator : MonoBehaviour
{
    
    public GameObject[] titlePrefabs;

    [SerializeField] private Transform _player;
    private List<GameObject> _activeTiltles = new List<GameObject>();
    private float _spawnPosition=0;
    private float _titleLength = 100;
    private int _startTitles = 8;

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
        GameObject newTitle=Instantiate(titlePrefabs[tileindex],transform.forward* _spawnPosition,transform.rotation);
        _activeTiltles.Add(newTitle);
        _spawnPosition += _titleLength;
    }
    private void DeleteTitle()
    {
        Destroy(_activeTiltles[0]);
        _activeTiltles.RemoveAt(0);
    }
}
