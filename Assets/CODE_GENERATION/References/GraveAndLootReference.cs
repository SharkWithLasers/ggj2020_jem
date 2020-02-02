using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class GraveAndLootReference : BaseReference<GraveAndLoot, GraveAndLootVariable>
	{
	    public GraveAndLootReference() : base() { }
	    public GraveAndLootReference(GraveAndLoot value) : base(value) { }
	}
}