using System;
using UnityEngine;
using UnityEngine.UI;

namespace Framework
{
	namespace Utils
	{
		[Serializable]
		public struct MaterialRefProperty
		{
			#region Serialized Data
			[SerializeField]
			private Material _material;
			[SerializeField]
			private int _materialIndex;
			[SerializeField]
			private Renderer _renderer;
			[SerializeField]
			private Graphic _graphic;	
			#endregion

			public MaterialRefProperty(Material material = null, int materialIndex=0, Renderer renderer=null, Graphic graphic=null)
			{
				_material = material;
				_materialIndex = materialIndex;
				_renderer = renderer;
				_graphic = graphic;
			}

			public static implicit operator Material(MaterialRefProperty property)
			{
				return property.GetMaterial();
			}

			public static implicit operator MaterialRefProperty(Material value)
			{
				return new MaterialRefProperty(value);
			}

			public Material GetMaterial()
			{
				//If material is null...
				if (_material == null)
				{
					//...get from UI graphic
					if (_materialIndex == MaterialRef.kGraphicMaterialIndex)
					{
						if (_graphic != null)
						{
							_material = _graphic.material;
						}
					}
					//...get from renderer / index
					else if (_materialIndex != -1 )
					{
						if (_renderer != null && 0 <= _materialIndex && _materialIndex < _renderer.sharedMaterials.Length)
						{
							_material = _renderer.materials[_materialIndex];
						}
					}
				}

				return _material;
			}
		}
	}
}