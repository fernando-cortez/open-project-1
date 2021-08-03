using Unity.Multiplayer.Netcode;
using UnityEngine;

public class ServerDestroyAfterDuration : NetworkBehaviour
{
	// TODO: can convert this into SO
	[SerializeField]
	float m_Duration;

	float m_SpawnTime;

	public override void OnNetworkSpawn()
	{
		if (!IsServer)
		{
			enabled = false;
			return;
		}

		m_SpawnTime = Time.time;
	}

	void Update()
	{
		if (Time.time > m_SpawnTime + m_Duration)
		{
			Destroy(gameObject);
		}
	}
}
