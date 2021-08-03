using UnityEngine;
using UOP1.StateMachine;
using UOP1.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "ApplyMovementVector", menuName = "State Machines/Actions/Consume Shot")]
public class ConsumeShotActionSO : StateActionSO<ConsumeShotAction> { }

public class ConsumeShotAction : StateAction
{
	//Component references
	private Protagonist _protagonistScript;

	public override void Awake(StateMachine stateMachine)
	{
		_protagonistScript = stateMachine.GetComponent<Protagonist>();
	}

	public override void OnStateEnter()
	{
		_protagonistScript.ConsumeShootInput();
	}

	public override void OnUpdate()
	{

	}
}
