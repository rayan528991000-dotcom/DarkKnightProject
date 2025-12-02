
using UnityEngine;

public class EnemyWight : MonoBehaviour
{
    public float health = 100f;
    void Update()
    {
        transform.LookAt(GameObject.FindWithTag("Player").transform);
    }
}
