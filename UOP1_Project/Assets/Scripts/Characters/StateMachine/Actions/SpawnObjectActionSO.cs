using Unity.Multiplayer.Netcode;
using UnityEngine;
using UOP1.StateMachine;
using UOP1.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "SpawnObjectAction", menuName = "State Machines/Actions/Spawn Object Action")]
public class SpawnObjectActionSO : StateActionSO<SpawnObjectAction>
{
	public GameObject objectToSpawn;
}

public class SpawnObjectAction : StateAction
{
	//Component references
	private Protagonist _protagonistScript;

	private SpawnObjectActionSO _originSO => (SpawnObjectActionSO)base.OriginSO; // The SO this StateAction spawned from

	public override void Awake(StateMachine stateMachine)
	{
		_protagonistScript = stateMachine.GetComponent<Protagonist>();
	}

	public override void OnStateEnter()
	{
		var objectClone = GameObject.Instantiate(_originSO.objectToSpawn,
			_protagonistScript.transform.position + _protagonistScript.transform.forward,
			Quaternion.LookRotation(_protagonistScript.transform.forward));

		var objectCloneNetworkObject = objectClone.GetComponent<NetworkObject>();

		objectCloneNetworkObject.Spawn();
	}

	public override void OnUpdate()
	{

	}
}
