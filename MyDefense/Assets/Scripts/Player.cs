using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Vector2 rawInput;

    Shooter shooter;

    void Awake() {
        shooter = GetComponent<Shooter>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (shooter) {
            shooter.isFiring = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
        transform.position += delta;
    }

    void OnMove(InputValue value) {
        rawInput = value.Get<Vector2>();
        // Debug.Log(rawInput);
    }

    void OnFire(InputValue value) {
        if (shooter) {
            shooter.isFiring = value.isPressed;
        }
    }
}
