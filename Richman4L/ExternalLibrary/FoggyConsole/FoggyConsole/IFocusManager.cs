using FoggyConsole . Controls ;

namespace FoggyConsole
{

	/// <summary>
	///     Represents a class which can handle focus changed. The standard implementation is <code>FocusManager</code>
	/// </summary>
	public interface IFocusManager
	{

		/// <summary>
		///     The currently focused control
		/// </summary>
		Control FocusedControl { get ; }

		/// <summary>
		///     Called if the control-tree has been changed
		/// </summary>
		void ControlTreeChanged ( ) ;

	}

}
