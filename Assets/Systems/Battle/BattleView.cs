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

    public Button theButton;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerController.instance.player;
        SetPlayerHealth(player.healthCurrent, player.healthMax);
    }

    public void SetPlayerHealth(int _healthCurrent, int _healthMax) {
        playerHealth.text = _healthCurrent.ToString() + " / " + _healthMax.ToString();
    }
    public void SetEnemyHealth(int _healthCurrent, int _healthMax)
    {
        enemeyHealth.text = _healthCurrent.ToString() + " / " + _healthMax.ToString();
    }
}
