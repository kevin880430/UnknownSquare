using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadControl : MonoBehaviour
{
    public float jumpforce = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        }
    }

}
