using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab; // 生成する敵のプレファブ
    public float spawnXPosition = 6.5f; // 生成位置のX座標
    public float minMass = 1.0f; // Massの最小値
    public float maxMass = 5.0f; // Massの最大値
    public float minGravityScale = 0.5f; // GravityScaleの最小値
    public float maxGravityScale = 2.0f; // GravityScaleの最大値

    public float minSpawnInterval = 3.0f; // 生成間隔の最小値
    public float maxSpawnInterval = 7.0f; // 生成間隔の最大値


    // Start is called before the first frame update
    void Start()
    {
        // 一定の時間ごとに敵を生成するコルーチンを開始
        StartCoroutine(SpawnEnemyCoroutine());
    }

    IEnumerator SpawnEnemyCoroutine()
    {
        while (true)
        {
            // ランダムなMassとGravityScaleを生成
            float randomMass = Random.Range(minMass, maxMass);
            float randomGravityScale = Random.Range(minGravityScale, maxGravityScale);

            // 敵を生成
            GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(spawnXPosition, 0, 0), Quaternion.identity);

            // 生成した敵のRigidbody2Dコンポーネントを取得して設定
            Rigidbody2D enemyRigidbody2D = newEnemy.GetComponent<Rigidbody2D>();
            if (enemyRigidbody2D != null)
            {
                enemyRigidbody2D.mass = randomMass;
                enemyRigidbody2D.gravityScale = randomGravityScale;
            }
            // ランダムな生成間隔を設定
            float randomSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

            // ランダムな間隔待機して次の生成へ
            yield return new WaitForSeconds(randomSpawnInterval);
        

        }
    }
}
