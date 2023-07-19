using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDelegateExercise
{
    public delegate void SpinDelegate(ref int energyLevel, ref int winningProbability);
    public class GameManager
    {
       
        private int energyLevel;
        private int winningProbability;
        public void PlayGame()
        {
            Console.WriteLine("Enter your name:");
            string playerName=Console.ReadLine();
            Console.WriteLine("Enter your lucky number from 1 to 10:");
            int luckyNumber=Convert.ToInt32(Console.ReadLine());
            energyLevel = 1;
            winningProbability=100;
            SpinDelegate[] spinDelegates=new SpinDelegate[5];
            spinDelegates[0] = FirstSpin;
            spinDelegates[1] = SecondSpin;
            spinDelegates[2] = ThirdSpin;
            spinDelegates[3] = FourthSpin;
            spinDelegates[4] = FifthSpin;

            for (int i = 0; i < spinDelegates.Length; i++)
            {
                Console.WriteLine($"Spin {i + 1}:");
                spinDelegates[i].Invoke(ref energyLevel, ref winningProbability);
            }
            Console.WriteLine("TenthSpin: Energy Level+1,Winning Probability+100");
            energyLevel += 1;
            winningProbability += 100;
            Console.WriteLine("Winner:");
            if(energyLevel >=1 && winningProbability >=50)
            {
                Console.WriteLine($"{playerName} is the winner!!");
            }
            else
            {
                Console.WriteLine($"{playerName} did not win");
            }
            Console.WriteLine($"Energy level at Runner Up:{energyLevel} and winning Probability more than 60");
            if(energyLevel >=1 && winningProbability >50)
            {
                Console.WriteLine($"{playerName} is not a loser!");
            }
            else
            {
                Console.WriteLine($"{playerName} is a loser");
            }
            Console.ReadLine();
        }
        private void FirstSpin(ref int energyLevel, ref int winningProbability)
        {
            energyLevel += 1;
            winningProbability += 10;
        }
        private void SecondSpin(ref int energyLevel, ref int winningProbability)
        {
            energyLevel += 2;
            winningProbability += 20;
        }
        private void ThirdSpin(ref int energyLevel, ref int winningProbability)
        {
            energyLevel += 3;
            winningProbability += 30;
        }
        private void FourthSpin(ref int energyLevel, ref int winningProbability)
        {
            energyLevel += 4;
            winningProbability += 40;
        }
        private void FifthSpin(ref int energyLevel, ref int winningProbability)
        {
            energyLevel += 5;
            winningProbability += 50;
        }
    }
}
