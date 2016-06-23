using UnityEngine;

/// <summary>
/// Be aware this will not prevent a non singleton constructor
///   such as `T myT = new T();`
/// To prevent that, add `protected T () {}` to your singleton class.
/// 
/// As a note, this is made as MonoBehaviour because we need Coroutines.
/// </summary>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T _instance;

	private static object _lock = new object();

	public static T Instance
	{
		get
		{
			if (applicationIsQuitting) {
				Debug.LogWarning("[Singleton] La instancia '"+ typeof(T) +
					"' ya fue destruida al salide de la aplicacion. " +
					" No se creara neuvamente - Devolviendo null.");
				return null;
			}

			lock(_lock)
			{
				if (_instance == null)
				{
					_instance = (T) FindObjectOfType(typeof(T));

					if ( FindObjectsOfType(typeof(T)).Length > 1 )
					{
						Debug.LogError("[Singleton] Algo salio muy mal " +
							" - nunca deberia haber mas de una instancia de singleton!" +
							" Reabrir la escena podria arreglarlo.");
						return _instance;
					}

					if (_instance == null)
					{
						GameObject singleton = new GameObject();
						_instance = singleton.AddComponent<T>();
						singleton.name = "(singleton) "+ typeof(T).ToString();

						DontDestroyOnLoad(singleton);

						Debug.Log("[Singleton] Una instancia de " + typeof(T) + 
							" es necesaria en la escena, por lo que '" + singleton +
							"' fue creado con DontDestroyOnLoad.");
					} else {
						Debug.Log("[Singleton] Usando la instancia ya creada: " +
							_instance.gameObject.name);
					}
				}

				return _instance;
			}
		}
	}

	private static bool applicationIsQuitting = false;
	/// <summary>
	/// When Unity quits, it destroys objects in a random order.
	/// In principle, a Singleton is only destroyed when application quits.
	/// If any script calls Instance after it have been destroyed, 
	///   it will create a buggy ghost object that will stay on the Editor scene
	///   even after stopping playing the Application. Really bad!
	/// So, this was made to be sure we're not creating that buggy ghost object.
	/// </summary>
	public void OnDestroy () {
		applicationIsQuitting = true;
	}
}