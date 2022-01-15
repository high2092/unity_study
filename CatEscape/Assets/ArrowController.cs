using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -0.01f, 0);

        if (transform.position.y < -5.0f) {
            Destroy(gameObject); // 메모리 해제; gameObject: 객체 자신을 나타냄; Q. this랑 무슨 차이?
        }

        Vector2 p1 = transform.position;
        Vector2 p2 = this.player.transform.position;
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;

        float r1 = 0.5f, r2 = 0.85f; // 각각 화살과 플레이어의 반지름

        if (d <= r1+r2) {
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DescreaseHp();
            Destroy(gameObject);
        }
    }
}
