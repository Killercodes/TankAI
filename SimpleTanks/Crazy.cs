using System;
using TankAILib;

namespace TankAI.SimpleTanks
{
	/// <summary>
	/// Sample tank that moves randomly left or right and avoids hitting walls
	/// </summary>
	public class Crazy : Tank
	{
		private Random random;
		private int direction;

		public Crazy(NewTankArgs e): base(e)
		{
			// Initialize tank settings.
			random = new Random();			
            Forward();
			direction = 1;
			TurnLeft(Heading + 15);
		}

		public override void Tick()
		{
			// Calculate where my new position will be 
			double newX = X + Math.Cos(Heading * Math.PI / 180.0) * Speed;
			double newY = Y + Math.Sin(Heading * Math.PI / 180.0) * Speed;

			// Calculate how far I am currently way from the center, and how far I will be away from the center.
			double distanceFromCenter = Math.Sqrt(Math.Pow(BattleFieldWidth / 2 - X, 2) + Math.Pow(BattleFieldHeight / 2 - Y, 2));
			double newDistanceFromCenter = Math.Sqrt(Math.Pow(BattleFieldWidth / 2 - newX, 2) + Math.Pow(BattleFieldHeight / 2 - newY, 2));           			

			// If I'm too close to a wall, and I am moving toward the wall, reverse my direction to avoid it.
			if (newX < Height * 2 || newY < Height * 2 || 
				newX > BattleFieldWidth - Height * 2 || newY > BattleFieldHeight - Height * 2)
			{
				if (newDistanceFromCenter > distanceFromCenter)
				{
					reverse();
				}
			}
		}

		public override void CompletedTurn()
		{
			// Randomly turn right or left
			if (random.Next(2) == 1)
			{
				TurnLeft(Heading + 45);
			}
			else
			{
				TurnRight(Heading - 45);
			}
		}

		public override void HitTank(HitTankArgs e)
		{
			reverse();
		}

		public override void HitWall()
		{
			reverse();
		}

		private void reverse()
		{
			// Reverse direction.
			direction *= -1;
			if (direction == 1)
			{
				Forward();
			}
			else
			{
				Backward();				
			}
		}

		public override void ScannedTank(TankArgs e)
		{
			Fire(1);
		}
	}
}
