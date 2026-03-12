using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    Volume vol;
    public float DownPerAir;
    SpriteRenderer sprite;
    bool one;
    [SerializeField] Transform FindingOb;
    private void Awake()
    {
        pc = GetComponent<PlayerController>();
        one = true;
        vol = Camera.main.GetComponent<Volume>();
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Hp = maxHp;
            Air = maxAir;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            NotDie = !NotDie;
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            GameManager.Instance.Init();
        }
        if (!die)
        {
            if (!NotDie)
            {
                if (Air > 0)
                {
                    Air -= DownPerAir * Time.deltaTime;
                }
                else
                {
                    Air = 0;
                    Invin = true;
                    die = true;
                }
            }
            else Invin = true;
            vol.weight = 1 - Air / maxAir;

            Speed = 5 - 2 * (Weight / maxWeight);
        }
        else if(one)
        {
            Dead.color += Color.black * Time.deltaTime;
            if (Dead.color.a >= 1)
            {
                one = false;
                StartCoroutine(Die());
            }
        }
    }
    public bool Dark;
    public float Speed;
    public float Hp;
    public float maxHp;
    public float Air;
    public float maxAir;
    public float InvenSize;
    public float Weight;
    public float maxWeight;
    public List<int> Inventory;
    public bool Invin;
    public float InvinTime;

    public Interact InteractOb;

    public Transform[] StartPoint;
    public Transform[] ExitPoint;

    bool die;

    [SerializeField] Transform InvenOb;
    [SerializeField] SpriteRenderer Dead;
    PlayerController pc;

    public bool NotDie;

    [SerializeField] AudioClip HitS;
    IEnumerator Die()
    {
        pc.enabled = false;
        yield return new WaitForSeconds(1);
        GameManager.Instance.Init();
    }
    public void Hit(int Damage)
    {
        if (!Invin)
        {
            transform.GetChild(0).GetComponent<AudioSource>().Play();
            Hp -= Damage;
            if (Hp <= 0)
            {
                Invin = true;
                Hp = 0;
                die = true;
            }
            else StartCoroutine(Invintime());
        }
    }
    public void PlayerInit()
    {
        Dark = false;
        InteractOb = null;
        Invin = false;
        Air = maxAir;
        Hp = maxHp;
        Weight = 0;
        die = false;
        one = true;
        Dead.color = Color.black;
        StartCoroutine(PadeIn());
        InvenLoad();
        transform.position = StartPoint[0].position;
        Camera.main.transform.position = new Vector3(0, 0, -10);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        gameObject.SetActive(true);
        pc.Flash.transform.rotation = Quaternion.Euler(0, 0, 0);
        pc.enabled = true;
    }
    IEnumerator PadeIn()
    {
        yield return new WaitForSeconds(0.3f);
        for (; Dead.color.a > 0;)
        {
            Dead.color -= Color.black * Time.deltaTime;
            yield return new WaitForSeconds(0.01f);
        }
    }
    IEnumerator Invintime()
    {
        Invin = true;
        for (int i = 0; i < 4; i++)
        {
            sprite.color = Color.white - Color.black * 0.5f;
            yield return new WaitForSeconds(InvinTime / 8);
            sprite.color = Color.white;
            yield return new WaitForSeconds(InvinTime / 8);
        }
        Invin = false;
    }
    public bool AddItem(int number)
    {
        if (Inventory.Count < InvenSize && Weight + GameManager.Instance.ItemWeight[number] <= maxWeight)
        {
            Inventory.Add(number);
            InvenLoad();
            Weight += GameManager.Instance.ItemWeight[number];
            return true;
        }
        else
        {
            return false;
        }
    }
    public void MoveStage(bool up)
    {
        if (up)
        {
            if(GameManager.Instance.Stage < 5)
            {
                GameManager.Instance.Stage++;
                transform.position = StartPoint[GameManager.Instance.Stage - 1].position;
                Camera.main.transform.position = transform.position + new Vector3(0, 0, -10);
            }
        }
        else
        {
            GameManager.Instance.Stage--;
            transform.position = ExitPoint[GameManager.Instance.Stage - 1].position;
            Camera.main.transform.position = transform.position + new Vector3(0, 0, -10);
        }

    }
    public void StageWarp(int n)
    {
        GameManager.Instance.Stage = n;
        transform.position = StartPoint[GameManager.Instance.Stage - 1].position;
        Camera.main.transform.position = transform.position + new Vector3(0, 0, -10);
    }
    public void InvenLoad()
    {
        for (int i = 0; i < 8; i++)
        {
            InvenOb.GetChild(i).gameObject.SetActive(false);
        }
        for (int i = 0; i < InvenSize; i++)
        {
            InvenOb.GetChild(i).gameObject.SetActive(true);
            InvenOb.GetChild(i).GetChild(0).GetComponent<Image>().sprite = null;
        }
        for (int i = 0; i < Inventory.Count; i++)
        {
            InvenOb.GetChild(i).GetChild(0).GetComponent<Image>().sprite = GameManager.Instance.ItemImages[Inventory[i]];
        }
    }
    public void UseItem(int Invennum)
    {
        if (Inventory[Invennum] < 7)
        {
            switch (Inventory[Invennum])
            {
                case 0:Hp += 20;
                    if (Hp > maxHp) Hp = maxHp;
                    break;
                case 1:
                    Air += 50;
                    if (Air > maxAir) Air = maxAir;
                    break;
                case 2:
                    FindingOb.gameObject.SetActive(true);
                    break;
                case 3:
                    StartCoroutine(SpeedUp(1));
                    break;
                case 4:
                    StartCoroutine(SpeedUp(2));
                    break;
                case 5:StartCoroutine(DarkT());
                    break;
                case 6:
                    transform.position = StartPoint[0].position;
                    Camera.main.transform.position = new Vector3(0, 0, -10);
                    break;
            }
            Inventory.RemoveAt(Invennum);
            InvenLoad();
        }
    }
    IEnumerator DarkT()
    {
        Dark = true;
        yield return new WaitForSeconds(20);
        Dark = false;
    }
    IEnumerator SpeedUp(int Level)
    {
        if (Level == 1)
        {
            Speed = 6;
        }else
        {
            Speed = 7.5f;
        }
        yield return new WaitForSeconds(10);
        Speed = 5;
    }
}
