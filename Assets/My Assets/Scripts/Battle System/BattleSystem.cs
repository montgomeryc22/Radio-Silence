using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

	public GameObject Player;
	public GameObject Enemy;
	public Animator animator;

	public Transform playerBattleStation;
	public Transform enemyBattleStation;

	Unit playerUnit;
	Unit enemyUnit;

	public Text dialogueText;

	public BattleHUD playerHUD;
	public BattleHUD enemyHUD;

	public BattleState state;
	public Button Run;

    // Start is called before the first frame update
    void Start()
    {
		state = BattleState.START;
		StartCoroutine(SetupBattle());

		Run = GetComponent<Button>();
		Run.onClick.AddListener(QuitGame);
    }

		public void QuitGame()
		{
			Application.Quit();
		}

	IEnumerator SetupBattle()
	{
		GameObject playerGO = Instantiate(Player, playerBattleStation);
		playerUnit = playerGO.GetComponent<Unit>();

		GameObject enemyGO = Instantiate(Enemy, enemyBattleStation);
		enemyUnit = enemyGO.GetComponent<Unit>();

		dialogueText.text = enemyUnit.unitName + " is preparing to hurt you...";

		playerHUD.SetHUD(playerUnit);
		enemyHUD.SetHUD(enemyUnit);

		yield return new WaitForSeconds(3f);

		state = BattleState.PLAYERTURN;
		PlayerTurn();
	}

	IEnumerator PlayerRun()
	{
		playerHUD.SetHP(playerUnit.currentHP);
		dialogueText.text = "You got away swiftly!";

		yield return new WaitForSeconds(3f);
		EndBattle();
	}

	IEnumerator PlayerAttack()
	{
		dialogueText.text = "You choose to attack!";
		yield return new WaitForSeconds(1f);
		bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
		enemyHUD.SetHP(enemyUnit.currentHP);
		dialogueText.text = "The attack is successful!";
		yield return new WaitForSeconds(2f);

		if(isDead)
		{
			state = BattleState.WON;
			EndBattle();
		} else
		{
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}
	}

	IEnumerator PlayerBefriend()
	{
		playerHUD.SetHP(playerUnit.currentHP);
		dialogueText.text = "You really want to be my friend?";
		yield return new WaitForSeconds(1f);
		bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
		enemyHUD.SetHP(enemyUnit.currentHP);
		dialogueText.text = "No, you're just trying to trick me";

		yield return new WaitForSeconds(3f);

		if(isDead)
		{
			state = BattleState.WON;
			EndBattle();
		} else
		{
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}
	}


// Work on Player Code and Incorporating Keyboard.

/**	IEnumerator PlayerCode()
	{
		playerHUD.SetHP(playerUnit.currentHP);
		dialogueText.text = "You really want to be my friend?";
		enemyHUD.SetHP(enemyUnit.currentHP);
		dialogueText.text = "No, you're just trying to trick me";

		yield return new WaitForSeconds(3f);

		if(isDead)
		{
			state = BattleState.WON;
			EndBattle();
		} else
		{
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}
	}
**/



	IEnumerator PlayerDespawn()
	{
		playerHUD.SetHP(playerUnit.currentHP);
		dialogueText.text = "Bye bye!";

		yield return new WaitForSeconds(3f);

		state = BattleState.WON;
			EndBattle();
	}

	IEnumerator EnemyTurn()
	{
		dialogueText.text = enemyUnit.unitName + " attacks!";
		animator.SetBool("Attack", true);
		yield return new WaitForSeconds(2.8f);
		dialogueText.text = enemyUnit.unitName + " attack is successful!";
		animator.SetBool("Attack", false);
		bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

		playerHUD.SetHP(playerUnit.currentHP);

		yield return new WaitForSeconds(2f);

		if(isDead)
		{
			state = BattleState.LOST;
			EndBattle();
		} else
		{
			state = BattleState.PLAYERTURN;
			PlayerTurn();
		}

	}

	void EndBattle()
	{
		if(state == BattleState.WON)
		{
			dialogueText.text = "You won the battle!";
		} else if (state == BattleState.LOST)
		{
			dialogueText.text = "You were defeated.";
		}
	}

	void PlayerTurn()
	{
		dialogueText.text = "Choose an action:";
	}

	IEnumerator PlayerHeal()
	{
		playerUnit.Heal(5);

		playerHUD.SetHP(playerUnit.currentHP);
		dialogueText.text = "You feel renewed strength!";

		yield return new WaitForSeconds(3f);

		state = BattleState.ENEMYTURN;
		StartCoroutine(EnemyTurn());
	}

	public void OnAttackButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerAttack());
	}

	public void OnBefreindButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerBefriend());
	}

	public void OnCodeButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerBefriend());
	}

	public void OnDespawnButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerDespawn());
	}

	public void OnHealButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerHeal());
	}

	public void OnRunButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;
		StartCoroutine(PlayerRun());
	}
}
