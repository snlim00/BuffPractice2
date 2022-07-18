using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static T CheckEnumContainsString<T>(string source) where T : notnull, Enum
    {
        string[] s = Enum.GetNames(typeof(T));

        for (int i = 0; i < Enum.GetValues(typeof(T)).Length; ++i)
        {
            if (s[i] == source)
            {
                return (T)(object)i;
            }
        }

        Debug.LogError("CheckEnumContainsString : '" + source + "' 해당 문자열을 가진 Enum값을 찾을 수 없습니다.");
        return (T)(object)0;
    }
}