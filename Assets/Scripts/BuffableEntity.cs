using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class BuffableEntity : MonoBehaviour
{
    public EntityStat eStat;

    private List<Buff> buffList = new List<Buff>();


    public Rigidbody2D rig;

    private void Awake()
    {
        //InitManager.initEvent[0] += Init;

        Init();
    }

    protected virtual void Init()
    {
        eStat = new EntityStat();

        rig = GetComponent<Rigidbody2D>();
    }


    protected virtual void Update()
    {
        BuffTimerProcess();
    }

    private void BuffTimerProcess()
    {
        if (buffList.Count > 0)
        {
            Debug.Log(nameof(BuffTimerProcess));

            for (int i = buffList.Count - 1; i >= 0; --i)
            {
                buffList[i].remainingDuration = buffList[i].duration - (Time.time - buffList[i].buffStartTime);

                if (buffList[i].remainingDuration <= 0)
                {
                    ReleaseBuff(buffList[i]);
                }
            }
        }
    }
    public virtual void GiveBuff(Buff buff)
    {
        ApplyBuff(new Buff(buff));
    }

    protected void ApplyBuff(Buff buff)
    {
        Stat targetStat = eStat.stats[buff.targetStat];

        targetStat.SetValue(targetStat.value + buff.value);

        buff.buffStartTime = Time.time;

        buff.remainingDuration = buff.duration;

        buffList.Add(buff);

        Buff.Log(buff);

        Debug.Log(nameof(ApplyBuff));
    }

    protected void ReleaseBuff(Buff buff)
    {
        Stat targetStat = eStat.stats[buff.targetStat];

        targetStat.SetValue(targetStat.value - buff.value);

        buffList.Remove(buff);

        Debug.Log(nameof(ReleaseBuff));
    }
}
