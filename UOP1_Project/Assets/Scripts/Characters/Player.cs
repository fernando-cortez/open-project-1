using MLAPI;
using UnityEngine;

public class Player : NetworkBehaviour
{
	[SerializeField]
	TransformEventChannelSO m_PlayerSpawnedChannel;

	public override void OnNetworkSpawn()
	{
		if (IsClient && IsLocalPlayer &&
			m_PlayerSpawnedChannel)
		{
			m_PlayerSpawnedChannel.RaiseEvent(transform);
		}
	}
}
