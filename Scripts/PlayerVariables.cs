using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Varibles")]
public class PlayerVariables : ScriptableObject
{
    public int playerLife;

    public int playerRubys;
    public int playerPoints;
    public int playerWaterAmmunition;

    public bool rechargeAvailable;
    public bool rechargeAnimation;
    public bool fullRubies;
    public bool rubyInPlayer;

}
