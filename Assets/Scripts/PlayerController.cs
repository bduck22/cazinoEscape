using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D PlayerRb;
    [SerializeField] private Animator PAni;
    PlayerData PD;
    Vector2 move;
    public Transform Flash;
    AudioSource AS;
    AudioClip Step;
    void Start()
    {

        AS = GetComponent<AudioSource>();
        PD = GetComponent<PlayerData>();
    }
    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                Flash.rotation = Quaternion.Euler(0, 180, 270);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }else
            {
                Flash.rotation = Quaternion.Euler(0, 0, 270);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            PAni.SetTrigger("Move");
            move.x = PD.Speed * Input.GetAxisRaw("Horizontal");
        }
        else
        {
            move.x = 0;
        }
        if (Input.GetButton("Vertical"))
        {
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                Flash.rotation = Quaternion.Euler(0, 0, 0);
            }else
            {
                Flash.rotation = Quaternion.Euler(0, 0, 180);
            }
            PAni.SetTrigger("Move");
            move.y = PD.Speed * Input.GetAxisRaw("Vertical");
        }
        else
        {
            move.y = 0;
        }
        if (!Input.GetButton("Horizontal") && !Input.GetButton("Vertical"))
        {
            AS.enabled = false;
            AS.enabled = false;
            PAni.SetTrigger("Stop");
            move = Vector2.zero;
        }
        else
        {
            AS.enabled = true;
        }
        PlayerRb.velocity = move;

        if (Input.GetKeyDown(KeyCode.A))
        {
            PAni.SetTrigger("Attack");
        }
    }
}
