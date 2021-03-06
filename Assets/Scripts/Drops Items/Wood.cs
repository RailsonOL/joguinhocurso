using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeMove;

    private float timeCount;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")){
            collision.GetComponent<PlayerItems>().totalWood++;
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if (timeCount < timeMove)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }   
    }
}
