using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script handles variables that will not reset after scene changes - Adrian
public class StaticVariableHolder : MonoBehaviour
{
    public static int permaCoins;
    public static bool staticEasy = false;
    public static bool staticMedium = false;
    public static bool staticHard = false;
    public static bool staticImpossible = false;
    public static string test;
}       
