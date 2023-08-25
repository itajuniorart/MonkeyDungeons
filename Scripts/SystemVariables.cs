using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "System Variables")]
public class SystemVariables : ScriptableObject
{
    public bool tutorial;
    public bool fullAltar;
    public int enemySpawnRate;
    public int rubySpawnRate;
    
    public enum StateGame { START, PAUSE, WIN, GAMEOVER }
    public StateGame state;
    
}
