using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFollowing : MonoBehaviour
{
    Transform Target;
    PlayerData PD;
    private void Start()
    {
        PD = GameManager.Instance.PD;
    }
    private void OnEnable()
    {
        for(int i = GameManager.Instance.Stage - 1; i < 5; i++)
        {
            if (GameManager.Instance.Stage1[i].gameObject.activeSelf)
            {
                Target = GameManager.Instance.Stage1[i];
            }
        }
    }
    void Update()
    {
        transform.position = PD.transform.position;
        Vector3 dir = Target.position - transform.position;
        if(dir.x < 0)
        {

            transform.rotation = Quaternion.Euler(0, 0, Vector2.Angle(transform.position, dir));
        }else
        {
            if (dir.y > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, Vector2.Angle(transform.position, dir)-90);
            }
            else transform.rotation = Quaternion.Euler(0, 0, Vector2.Angle(transform.position, dir)+90);
        }
        if (!Target.gameObject.activeSelf) gameObject.SetActive(false);
    }
}
