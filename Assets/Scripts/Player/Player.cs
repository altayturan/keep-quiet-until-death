
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health;
    public int scrapMetal;
    public int bullet;
    [ContextMenu("Save")]
    public void Save()
    {
        DataSaver.Save(this);
    }
    [ContextMenu("Load")]
    public void Load()
    {
       Player player = DataSaver.Load(this);
    }
}
