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

        Debug.LogError("CheckEnumContainsString : '" + source + "' �ش� ���ڿ��� ���� Enum���� ã�� �� �����ϴ�.");
        return (T)(object)0;
    }
}