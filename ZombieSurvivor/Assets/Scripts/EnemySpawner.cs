using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //--------------------------
    public Enemy _enemyPrefab;         //	������ �� AI.
    public Transform[] _spawnPoints;    //	���� ��ġ.
                                        //--------------------------
                                        //	���ݷ�.
    public float _damageMax = 40f;      //	�ִ�.
    public float _damageMin = 20f;      //	�ּ�.

    //	ü��.
    public float _healthMax = 200f;     //	�ִ�.
    public float _healthMin = 100f;     //	�ּ�.

    //	�ӵ�.
    public float _speedMax = 200f;     //	�ִ�.
    public float _speedMin = 100f;     //	�ּ�.

    public Color _strongEnemyColor = Color.red; //	���� ���� ǥ���ϱ� ���� ��.

    List<Enemy> _enemies = new List<Enemy>();

    int _curWave = 0;

    private void Update()
    {
        if (GameManager.Instance != null &&
            GameManager.Instance.IsGameOver)
            return;

        if (_enemies.Count <= 0)
            SpawnWave();

        UpdateUI();
    }

    void UpdateUI() { UIManager.Instance.UpdateWaveText(_curWave,_enemies.Count); }

    void SpawnWave()
    {
        _curWave++;
        if(_curWave > 3)
        {
            StageManager._Inst.StageClear();
        }
        //	Mathf.RoundToInt..
        //	-	�Է°���
        //		�ݿø��� ���� ��ȯ..
        int spawnCount = Mathf.RoundToInt(_curWave * 1.5f);

        //	�� ����..
        for (int cur = 0; cur < spawnCount; ++cur)
        {
            float enemyIntensity = Random.Range(0f, 1f);
            CreateEnemy(enemyIntensity);
        }
    }
    void CreateEnemy(float intensity)
    {
        float health = Mathf.Lerp(_healthMin, _healthMax, intensity);

        float damage = Mathf.Lerp(_damageMin, _damageMax, intensity);

        float speed = Mathf.Lerp(_speedMin, _speedMax, intensity);

        Color skinColor = Color.Lerp(Color.white, _strongEnemyColor, intensity);

        Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];

        Enemy enemy = Instantiate( _enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        enemy.Setup(health, damage, speed, skinColor);
        _enemies.Add(enemy);

        enemy.OnDeath += () => _enemies.Remove(enemy);
        enemy.OnDeath += () => Destroy(enemy.gameObject, 10f);
        enemy.OnDeath += () => GameManager.Instance.AddScore(100);
    }
}
