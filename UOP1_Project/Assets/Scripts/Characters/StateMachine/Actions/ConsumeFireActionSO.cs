using UnityEngine;
using UOP1.StateMachine;
using UOP1.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "ConsumeFireAction", menuName = "State Machines/Actions/Consume Fire Action")]
public class ConsumeFireActionSO : StateActionSO<ConsumeFireAction> { }

public class ConsumeFireAction : StateAction
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
