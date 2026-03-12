using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Interact_Type
{
    Lever,
    item,
    Door,
    Ending
}
public class Interact : MonoBehaviour
{
    [SerializeField] Interact_Type Type;
    public int number;
    [SerializeField] Animator target;
    [SerializeField] bool Up;
    PlayerData PD;
    private void Start()
    {
        PD = GameManager.Instance.PD;
    }
    public void intaract()
    {
        PD.InteractOb = null;
        enabled = false;
        switch (Type)
        {
            case Interact_Type.Lever:
                GetComponent<Animator>().SetBool("Stop", false);
                target.SetBool("Stop", false);
                GetComponent<Animator>().enabled = true; 
                target.enabled = true;
                break;
            case Interact_Type.item:if (!PD.AddItem(number))
                {
                    PD.InteractOb = this;
                    enabled = true;
                }
                else gameObject.SetActive(false);
                if (number > 6)
                {
                    GetComponent<AudioSource>().Play();
                }

                break;
            case Interact_Type.Door:
                PD.MoveStage(Up);
                enabled = true;
                break;
            case Interact_Type.Ending:

                GameManager.Instance.End = true;
                SceneManager.LoadScene(2);
                break;
        }
    }
    public void back()
    {
        enabled = true;
        GetComponent<Animator>().SetBool("Stop", true);
        target.SetBool("Stop", true);
        GetComponent<Animator>().SetTrigger("Back");

        //GetComponent<Animator>().enabled = false;
        target.SetTrigger("Back");

        //target.enabled = false;
    }
}
