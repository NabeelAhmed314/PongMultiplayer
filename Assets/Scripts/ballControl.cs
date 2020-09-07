using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballControl : MonoBehaviour
{
    float randomNumber;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer(2));
    }

    private void Reset()
    {
        StopCoroutine("Timer");
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        transform.position = new Vector2(0f, 0f);
        StartCoroutine(Timer(0.5f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            if(collision.collider.tag == "Player")
            {
                GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);
                GetComponent<AudioSource>().Play();
            }
    }

    IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);
        GoBall();
    }

     void GoBall()
    {
        randomNumber = Random.Range(0, 2);
        if (randomNumber <= 0.5f)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(80, 10));
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-80, -10));
        }
    }

}
