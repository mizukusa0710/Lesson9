using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab; // ��������G�̃v���t�@�u
    public float spawnXPosition = 6.5f; // �����ʒu��X���W
    public float minMass = 1.0f; // Mass�̍ŏ��l
    public float maxMass = 5.0f; // Mass�̍ő�l
    public float minGravityScale = 0.5f; // GravityScale�̍ŏ��l
    public float maxGravityScale = 2.0f; // GravityScale�̍ő�l

    public float minSpawnInterval = 3.0f; // �����Ԋu�̍ŏ��l
    public float maxSpawnInterval = 7.0f; // �����Ԋu�̍ő�l


    // Start is called before the first frame update
    void Start()
    {
        // ���̎��Ԃ��ƂɓG�𐶐�����R���[�`�����J�n
        StartCoroutine(SpawnEnemyCoroutine());
    }

    IEnumerator SpawnEnemyCoroutine()
    {
        while (true)
        {
            // �����_����Mass��GravityScale�𐶐�
            float randomMass = Random.Range(minMass, maxMass);
            float randomGravityScale = Random.Range(minGravityScale, maxGravityScale);

            // �G�𐶐�
            GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(spawnXPosition, 0, 0), Quaternion.identity);

            // ���������G��Rigidbody2D�R���|�[�l���g���擾���Đݒ�
            Rigidbody2D enemyRigidbody2D = newEnemy.GetComponent<Rigidbody2D>();
            if (enemyRigidbody2D != null)
            {
                enemyRigidbody2D.mass = randomMass;
                enemyRigidbody2D.gravityScale = randomGravityScale;
            }
            // �����_���Ȑ����Ԋu��ݒ�
            float randomSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

            // �����_���ȊԊu�ҋ@���Ď��̐�����
            yield return new WaitForSeconds(randomSpawnInterval);
        

        }
    }
}
