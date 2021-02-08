using System;

using UnityEngine;

using JetBrains.Annotations;

namespace CookingPrototype.Kitchen {
	[RequireComponent(typeof(FoodPlace))]
	public sealed class FoodTrasher : MonoBehaviour {

		FoodPlace _place = null;
		float     _timer = 0f;
		float _doubleClickTimer = 0;
		float _timeForDoubleClick = 1f;
		bool _isClicked = false;

		void Start() {
			_place = GetComponent<FoodPlace>();
			_timer = Time.realtimeSinceStartup;
		}

		private void Update() {
			if ( _isClicked ) {
				_doubleClickTimer += Time.deltaTime;
				if ( _doubleClickTimer >= _timeForDoubleClick ) {
					_isClicked = false;
					_doubleClickTimer = 0;
				}
			}
		}

		/// <summary>
		/// Освобождает место по двойному тапу если еда на этом месте сгоревшая.
		/// </summary>
		[UsedImplicitly]
		public void TryTrashFood() {
			if ( !_isClicked ) {
				_isClicked = true;
			}
			else {
				GetComponent<FoodPlace>().FreePlace();
			}
		}
	}
}
