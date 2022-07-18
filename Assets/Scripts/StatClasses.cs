using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    public readonly int index;

    public float value { get; private set; }

    public float minValue { get; private set; }
    public float maxValue { get; private set; }

    public Stat(int index, float value, float minValue, float maxValue)
    {
        this.index = index;
        this.value = value;
        this.minValue = minValue;
        this.maxValue = maxValue;
    }

    public void SetMinValue(float value)
    {
        minValue = value;
    }

    public void SetMaxValue(float value)
    {
        maxValue = value;
    }

    public void SetValue(float value)
    {
        this.value = value;

        if (this.value > this.maxValue)
        {
            this.value = this.maxValue;
        }
        else if (this.value < this.minValue)
        {
            this.value = this.minValue;
        }
    }
}

public class EntityStat
{
    public Dictionary<StatName, Stat> stats;

    public float speed
    {
        get
        {
            return (stats[StatName.DefaultSpeed].value + stats[StatName.ExtraSpeed].value) * stats[StatName.SpeedMultiplier].value;
        }
    }

    public float jumpPower
    {
        get
        {
            return (stats[StatName.DefaultJumpPower].value);
        }
    }

    public EntityStat()
    {
        InitStatTemplate();

        stats = new Dictionary<StatName, Stat>();

        for (int i = 0; i < statTemplate.Count; ++i)
        {
            StatName statName = (StatName)i;

            stats[statName] = new Stat(i, statTemplate[statName].value, statTemplate[statName].minValue, statTemplate[statName].maxValue);
        }
    }


    public static Dictionary<StatName, Stat> statTemplate = null;

    public static void InitStatTemplate()
    {
        if (statTemplate != null)
            return;

        List<Dictionary<string, object>> statData = CSVReader.Read("DataTable/StatData.CSV");

        statTemplate = new Dictionary<StatName, Stat>();

        for (int i = 0; i < statData.Count; ++i)
        {
            statTemplate[(StatName)i] = new Stat(i, Convert.ToSingle(statData[i][nameof(STAT_DATA_KEY.VALUE)]), Convert.ToSingle(statData[i][nameof(STAT_DATA_KEY.MIN_VALUE)]), Convert.ToSingle(statData[i][nameof(STAT_DATA_KEY.MAX_VALUE)]));
        }
    }
}