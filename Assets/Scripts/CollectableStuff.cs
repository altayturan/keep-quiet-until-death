using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableStuff : MonoBehaviour
{
    public int value;
    public void Bullet(Player player) { player.GainBullet(value); }
    public void Scrap(Player player) { player.GainScrap(value); }
}
