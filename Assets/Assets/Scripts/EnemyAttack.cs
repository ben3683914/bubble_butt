using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAttack : MonoBehaviour
{
    public int bullets;
    public int damage;
    public int attackIntervalMin;
    public int attackIntervalMax;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;

    [SerializeField]
    private int currentAttackInterval;

    private void Awake()
    {
        SetNextAttackInterval();
    }

    private void Start()
    {
        StartCoroutine(WaitAttack());
    }

    void SetNextAttackInterval()
    {
        currentAttackInterval = Random.Range(attackIntervalMin, attackIntervalMax);
    }

    IEnumerator WaitAttack()
    {
        yield return new WaitForSeconds(currentAttackInterval);

        for(int i = 0; i < bullets; i++)
        {
            yield return new WaitForSeconds(Random.Range(0.2f, 0.75f));
            var clone = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            clone.GetComponent<BubbleBullet>().damage = damage;
        }

        SetNextAttackInterval();
        StartCoroutine(WaitAttack());
    }
}
