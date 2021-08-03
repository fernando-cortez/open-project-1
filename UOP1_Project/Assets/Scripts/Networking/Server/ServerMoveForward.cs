using Unity.Multiplayer.Netcode;
using UnityEngine;

public class ServerMoveForward : NetworkBehaviour
{
	// TODO: can convert this into SO
	[SerializeField]
	int m_MoveSpeed;

	public override void OnNetworkSpawn()
	{
		if (!IsServer)
		{
			enabled = false;
			return;
		}
	}

	void Update()
	{
		transform.Translate(Vector3.forward * (m_MoveSpeed * Time.deltaTime));
	}
}
