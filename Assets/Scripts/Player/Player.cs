using UnityEngine;

public class Player : MonoBehaviour
{
    public float health;
    public int scrapMetal;
    public int bullet;

    public float interval = 5f;
    public float startTime;
    private void Start()
    {
        startTime = Time.time;
    }
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

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.tag;
        if (tag == "Grass" || tag == "Garbage" || tag == "Lamp" || tag == "Tree")
            collision.GetComponent<EtkilesimliObje>().PlaySound();
    }
}
