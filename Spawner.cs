using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;

    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private int _spawned;
    private float _timeAfterLastSpawn;

    private void Start()
    {
        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if(_timeAfterLastSpawn >= _currentWave.Delay)
        {
            InstantiateEnemy();

            _spawned++;
            _timeAfterLastSpawn = 0;
        }

        if (_currentWave.Count <= _spawned)
            _currentWave = null;
    }

    public void SetWave(int index)
    {
        _currentWave = _waves[index];
    }

    private void InstantiateEnemy()
    {
        var enemy = Instantiate(_currentWave.Template, _spawnPoint.position, 
            _spawnPoint.rotation, _spawnPoint).GetComponent<Enemy>();

        enemy.Init(_player);
    }
}

[System.Serializable]
public class Wave
{
    public GameObject Template;
    public float Delay;
    public float Count; 
}
