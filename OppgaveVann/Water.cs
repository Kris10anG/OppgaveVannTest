using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OppgaveVann
{
    public enum WaterState
    {
        Solid,
        Fluid,
        Ice,
        Gas,
        FluidAndGas,
        IceAndFluid,
    }
    public class Water
    {
        public double Temperature { get; set; }
        public int Amount { get; set; }
        public double ProportionFirstState { get; set; }
        public WaterState State { get; set; }
       
        public Water( int amount, int temperature, double proportionFirstState = 0)
        {
            Temperature = temperature;
            Amount = amount;
            ProportionFirstState = proportionFirstState;



            State = WaterState.Fluid;
            if (temperature <= 0)
            {
                State = WaterState.Ice;
            }
            if (temperature == 120)
            {

                State = WaterState.Gas;
            }
            if (temperature == 0 || temperature == 100)
            {
                if (proportionFirstState == 0)
                {
                    throw new ArgumentException("When temperature is 0 or 100, you must provide a value for proportion");
                }
            }
            if (temperature == 100 && proportionFirstState == 0.3)
            {
                State = WaterState.FluidAndGas;
            }
            if (temperature == 100)
            {
                State = WaterState.FluidAndGas;
            }
            //if (temperature <= 100)
            //{
            //    State = WaterState.FluidAndGas;
            //}

           
        }
        public void AddEnergy(double energy)
        {
            var increaseTemp = (double)(energy / Amount);
            Temperature += increaseTemp;
            if (increaseTemp <= 0)
            {

            }
        }

    }
}
