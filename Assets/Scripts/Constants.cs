using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 대문자는 테이블을 가져올 때 키로 사용하는 값을 의미
 */



public enum STAT_DATA_KEY
{ 
    NAME, 
    VALUE,
    MIN_VALUE, 
    MAX_VALUE,
};

//새로운 스탯을 추가하고 싶다면 DataTable/StatData에서 새로운 행 추가 후 해당 스탯명을 STAT_NAME에 추가할 것.
public enum StatName
{ 
    DefaultSpeed,
    ExtraSpeed,
    SpeedMultiplier,
    DefaultJumpPower,
};

public enum BUFF_DATA_KEY
{
    NAME,
    TARGET_STAT,
    VALUE,
    DURATION,
    STACK_TYPE,
};

public enum BuffName
{
    TestSpeedUp,
    TestSpeedMult,
};