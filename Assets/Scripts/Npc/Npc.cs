using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public float speed;
    private float initialSpeed;
    private int index;
    private Animator anim;
    public List<Transform> paths = new List<Transform>();

    private void Start() {
        initialSpeed = speed;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(DialogueController.instance.isShowing)
        {
            speed = 0f;
            anim.SetBool("isWalking", false);
        }else
        {
            speed = initialSpeed;
            anim.SetBool("isWalking", true);
        }

        transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, paths[index].position) < 0.2f)
        {
            if (index < paths.Count - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }

        Vector2 direction = paths[index].position - transform.position;

        if(direction.x > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if(direction.x < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }

    }
}
