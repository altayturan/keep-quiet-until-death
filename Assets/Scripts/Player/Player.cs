
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.collider.tag;
        if (tag == "Grass" || tag == "Garbage" || tag == "Lamp" || tag == "Tree")
            collision.collider.GetComponent<EtkilesimliObje>().PlaySound();
    }
}
