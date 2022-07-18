using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff
{
    public enum StackType { Add, Cover };

    public enum BuffType { Buff, Debuff, Dummy };


    public BuffName name;

    public StackType stackType;

    public StatName targetStat;

    public float value;

    public float duration;

    public float buffStartTime = -1;

    public float remainingDuration;

    public bool isApplying = false;


    public Buff(BuffName name, StatName targetStat, float value, float duration, StackType stackType)
    {
        this.name = name;
        this.targetStat = targetStat;
        this.value = value;
        this.duration = duration;
        this.stackType = stackType;
    }
    public Buff(Buff buff) : this(buff.name, buff.targetStat, buff.value, buff.duration, buff.stackType)
    {
        
    }



    public static Dictionary<BuffName, Buff> definedBuff = null;

    public static void InitDefinedBuff()
    {
        if (definedBuff != null)
            return;

        List<Dictionary<string, object>> buffData = CSVReader.Read("DataTable/DefinedBuff.CSV");

        definedBuff = new Dictionary<BuffName, Buff>();

        for(int i = 0; i < buffData.Count; ++i)
        {
            BuffName name = Utility.CheckEnumContainsString<BuffName>(buffData[i][nameof(BUFF_DATA_KEY.NAME)].ToString());

            StatName statName = Utility.CheckEnumContainsString<StatName>(buffData[i][nameof(BUFF_DATA_KEY.TARGET_STAT)].ToString());

            StackType stackType = Utility.CheckEnumContainsString<StackType>(buffData[i][nameof(BUFF_DATA_KEY.STACK_TYPE)].ToString());

            definedBuff[(BuffName)i] = new Buff(name, statName, Convert.ToSingle(buffData[i][nameof(BUFF_DATA_KEY.VALUE)]), Convert.ToSingle(buffData[i][nameof(BUFF_DATA_KEY.DURATION)]), stackType);
        }

        Buff.Log(definedBuff[BuffName.TestSpeedUp]);
    }

    public static void Log(Buff buff)
    {
        Debug.Log(buff.targetStat + " " + buff.value + " " + buff.duration + " " + buff.stackType);
    }
}

public class DefinedBuff
{
    public static Buff testSpeedUp = new Buff(BuffName.TestSpeedUp, StatName.ExtraSpeed, 5, 5, Buff.StackType.Add);
} 