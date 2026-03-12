using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    PlayerData PD;
    [SerializeField] float CameraSpeed;
    void Start()
    {
        PD = GameManager.Instance.PD;
    }
    void Update()
    {
        CameraSpeed = PD.Speed;
        if (CameraSpeed < 4) CameraSpeed = 4;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(PD.transform.position.x, PD.transform.position.y,-10), CameraSpeed*Time.deltaTime);
    }
}