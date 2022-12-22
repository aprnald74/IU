using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerConter : MonoBehaviour
{
    float moveSpeed = 3;
    public GameObject[] Soul;
    int score = 0;

    public TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SoulCrate");
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //print(v);
        Vector3 dir = new Vector3 (h, v, 0);
        //transform.position += dir;
        GetComponent<Rigidbody2D>().velocity = (dir) * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("WALL"))
        {
            print("충돌");
            GetComponent<SpriteRenderer>().color = collision.collider.GetComponent<SpriteRenderer>().color;

            StopCoroutine("ColorBack");
            StartCoroutine("ColorBack");


        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GameObject"))
        {
            if (GetComponent<SpriteRenderer>().color
                == collision.GetComponent<SpriteRenderer>().color)
            {
                moveSpeed += 0.5f;
                score += 2;
                tmp.text = "스코어 : " + score;

                Destroy(collision.gameObject);
                GetComponent<AudioSource>().Play();
            }
            else
            {
                float x = Random.Range(-8f, 8f);
                float y = Random.Range(-3f, 4f);
                Vector3 pos = new Vector3(x, y, 0);
                collision.transform.position = pos;

                moveSpeed -= 0.5f;
                score -= 1;
                tmp.text = "스코어 : " + score;
            }
            

        }
    }

    IEnumerator ColorBack()
    {
        //print("A");
        //yield return new WaitForSeconds(2f);
        //print("B");
        //yield return new WaitForSeconds(2f);
        //print("C");
        yield return new WaitForSeconds(3f);

        //Color color = new Color32(255, 255, 255, 255);

        //GetComponent<SpriteRenderer>().color = color;
        GetComponent<SpriteRenderer>().color = Color.white;
        //StartCoroutine(ColorBack());
    }

    IEnumerator SoulCrate()
    {
        yield return new WaitForSeconds(3f);

        float x = Random.Range(-8f, 8f);
        float y = Random.Range(-3f, 4f);
        Vector3 pos = new Vector3(x, y, 0);

        int idx = Random.Range(0, 3 + 1);

        Instantiate(Soul[idx], pos,Quaternion.identity);

        StartCoroutine("SoulCrate");
    }

    
}
