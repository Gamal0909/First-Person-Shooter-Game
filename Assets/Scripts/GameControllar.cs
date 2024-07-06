using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Game")]
    public Player player;
    public GameObject enemyContainer;

    [Header("UI")]
    public Text healthText;
    public Text ammoText;
    public Text enemyText;

    private int initialEnemyCount;

    void Start()
    {
        initialEnemyCount = enemyContainer.GetComponentsInChildren<Enemy>().Length;
    }

    void Update()
    {
        UpdateText();
    }

    void UpdateText()
    {
        ammoText.text = "Ammo: " + player.Ammo;
        healthText.text = "Health: " + player.Health;
        int killedCount = 0;

        foreach (Enemy enemy in enemyContainer.GetComponentsInChildren<Enemy>())
        {
            if (enemy.Killed)
            {
                killedCount++;
            }
        }

        enemyText.text = "Enemies: " + (initialEnemyCount - killedCount);
    }
}