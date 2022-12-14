using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GoalCondition", menuName = "2ButtonGameJamRunner/GoalCondition", order = 0)]
public class GoalConditions : ScriptableObject
{

    public float minPlayerSize = 0;
    public float maxPlayerSize = 9999;

    public float minPlayerVertSpeed = 0;

    public float maxPlayerVertSpeed = 9999;

    public float minPlayerHoriSpeed = 0;

    public float maxPlayerHoriSpeed = 9999;


}
