using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : BuffableEntity
{
    protected override void Init()
    {
        base.Init();

        Buff.InitDefinedBuff();
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateStatInfo();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        MoveControl();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //GiveBuff(Buff.definedBuff[BuffName.TestSpeedMult]);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log(eStat.speed);
        }

        for(int i = 0; i < eStat.stats.Count; ++i)
        {
            statInfoValues[(StatName)i].text = eStat.stats[(StatName)i].value.ToString();
        }
    }

    private void MoveControl()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            Vector2 vel = rig.velocity;

            vel.x = Input.GetAxisRaw("Horizontal") * eStat.speed;

            rig.velocity = vel;
        }

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector2 vel = rig.velocity;

            vel.y = eStat.jumpPower;

            rig.velocity = vel;
        }

        //transform.Translate(Input.GetAxisRaw("Horizontal") * eStat.speed * Time.deltaTime, Input.GetAxisRaw("Vertical") * eStat.speed * Time.deltaTime, 0);
    }

    [SerializeField] private GameObject statPanel;
    [SerializeField] private GameObject statInfoPref;

    private Dictionary<StatName, TMP_Text> statInfoValues = new Dictionary<StatName, TMP_Text>();

    private void GenerateStatInfo()
    {
        for(int i = 0; i < eStat.stats.Count; ++i)
        {
            TMP_Text statName = Instantiate(statInfoPref).GetComponent<TMP_Text>();
            TMP_Text statValue = statName.transform.GetChild(0).GetComponent<TMP_Text>();

            statName.transform.SetParent(statPanel.transform);

            statName.transform.localScale = Vector2.one;

            statName.text = ((StatName)i).ToString();
            statValue.text = eStat.stats[(StatName)i].value.ToString();

            statName.transform.localPosition = new Vector2(-13f, 200 - (20 * i));

            statInfoValues[(StatName)i] = statValue;
        }
    }
}
