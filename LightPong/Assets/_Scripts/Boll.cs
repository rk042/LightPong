using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boll : MonoBehaviour
{

    private Rigidbody2D _rd;

    private void Awake()
    {
        _rd = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //_rd.AddForce(new Vector2(3, 3));
        //_rd.angularVelocity = 0.5f;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log($" Ball tag {other.gameObject.tag} name {other.gameObject.name}");
        _rd.AddForce(new Vector2(Random.Range(0,3), Random.Range(-1,10))*Time.deltaTime);
    }
}
