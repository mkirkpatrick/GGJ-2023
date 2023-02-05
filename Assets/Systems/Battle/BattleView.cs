using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BattleView : MonoBehaviour
{
    private Player player;
    public Enemy currentEnemy;
    public TMP_Text playerHealth;
    public TMP_Text enemeyHealth;

    public Image playerImage;
    public List<Sprite> beetles;
    public Image enemyImage;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerController.instance.player;
    }

    public void UpdateView(Player _player, Enemy _enemy) {
        SetPlayerHealth(_player.healthCurrent, _player.healthMax);
        SetEnemyHealth(_enemy.healthCurrent, _enemy.healthMax);

        SetPlayerImage(_player);
        SetEnemyImage(_enemy);
    }

    public void SetPlayerHealth(int _healthCurrent, int _healthMax) {
        playerHealth.text = _healthCurrent.ToString() + " / " + _healthMax.ToString();
    }
    public void SetEnemyHealth(int _healthCurrent, int _healthMax)
    {
        enemeyHealth.text = _healthCurrent.ToString() + " / " + _healthMax.ToString();
    }

    public void SetPlayerImage(Player _player) {
        switch (_player.currentClan.clanName)
        {
            case "Huma":
                playerImage.sprite = beetles[0];
                break;
            case "Mani":
                playerImage.sprite = beetles[1];
                break;
            case "Nih-Tee":
                playerImage.sprite = beetles[2];
                break;
        }
    }
    public void SetEnemyImage(Enemy _enemy)
    {
        enemyImage.sprite = _enemy.sprite;
    }
}
