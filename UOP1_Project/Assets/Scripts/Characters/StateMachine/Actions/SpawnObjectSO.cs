using Unity.Multiplayer.Netcode;
using UnityEngine;
using UOP1.StateMachine;
using UOP1.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "ApplyMovementVector", menuName = "State Machines/Actions/Spawn Object")]
public class SpawnObjectSO : StateActionSO<SpawnObject>
{
	public GameObject objectToSpawn;
}

public class SpawnObject : StateAction
{
	//Component references
	private Protagonist _protagonistScript;

	private SpawnObjectSO _originSO => (SpawnObjectSO)base.OriginSO; // The SO this StateAction spawned from

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
