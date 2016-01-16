using System;
using System.Windows.Forms;
using TankAILib;

namespace TankAI
{
	/// <summary>
	/// Main interface point to the TankAILib class library
	/// </summary>
	class TankAI
	{
		/// <summary>
		/// Main entry point of the application
		/// Any tank that you wish to complete must be registered in this method
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			// Create a new TankAI form
			frmTankAI tankAIForm = new frmTankAI();

			// Register your tanks here
			tankAIForm.RegisterTank(Type.GetType("TankAI.SimpleTanks.Track"));
			tankAIForm.RegisterTank(Type.GetType("TankAI.SimpleTanks.Corners"));
			tankAIForm.RegisterTank(Type.GetType("TankAI.SimpleTanks.Walls"));
			tankAIForm.RegisterTank(Type.GetType("TankAI.SimpleTanks.Spin"));
			tankAIForm.RegisterTank(Type.GetType("TankAI.SimpleTanks.Strafe"));						
			tankAIForm.RegisterTank(Type.GetType("TankAI.SimpleTanks.Crazy"));
                       
			// Start the application
            Application.Run(tankAIForm);
		}
	}
}
