using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour 
{
    private static LevelController _instance;
    public static LevelController Instance
    {
        get
        {
            return _instance;
        }
    }
    [SerializeField] private Text itemUIText;

    private int totalItemQty = 0, collectedQty = 0;

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);

        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        totalItemQty = GameObject.FindGameObjectsWithTag("Collectible").Length;
        ItemUIUpdate();
    }

    private void ItemCollected()
    {
        collectedQty++;
        ItemUIUpdate();

    }

    private void ItemUIUpdate()
    {
        itemUIText.text = collectedQty + "/" + collectedQty;
    }
}
