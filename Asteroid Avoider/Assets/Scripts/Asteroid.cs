using UnityEngine;

public class Asteroid : MonoBehaviour
{

    private float rotation;

    private void Start()
    {
        rotation = Random.Range(180f, 250f);
    }

    private void Update()
    {
        transform.Rotate(0f, 0f, rotation * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth == null)
            return;

        playerHealth.Crash();
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
