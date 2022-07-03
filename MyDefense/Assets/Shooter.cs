using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float firingRate = 2f;
    [SerializeField] float delayToReady = 1f;

    Coroutine firingCoroutine;
    public bool isFiring;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire() {
        if (isFiring && firingCoroutine == null) {
            firingCoroutine = StartCoroutine(FireContinuously());
        } else if (!isFiring && firingCoroutine != null) {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously() {
        yield return new WaitForSeconds(delayToReady);
        while (true) {
            GameObject instance = Instantiate(projectilePrefab, transform.position+new Vector3(0, 0.2f, 0), Quaternion.identity);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null) {
                rb.velocity = transform.right * projectileSpeed;
            }

            Destroy(instance, projectileLifetime);
            yield return new WaitForSeconds(firingRate);
        }
    }
}
