using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9OOP
{
    public interface ICar
    {
        bool EngineIsRunning { get; }

        void EngineStart();

        void EngineStop();

        void Refuel(double liters);

        void RunningIdle();

        void BrakeBy(int speed); // car #2

        void Accelerate(int speed); // car #2

        void FreeWheel(); // car #2
    }

    public interface IEngine
    {
        bool IsRunning { get; }

        void Consume(double liters);

        void Start();

        void Stop();
    }

    public interface IFuelTank
    {
        double FillLevel { get; }

        bool IsOnReserve { get; }

        bool IsComplete { get; }

        void Consume(double liters);

        void Refuel(double liters);
    }

    public interface IFuelTankDisplay
    {
        double FillLevel { get; }

        bool IsOnReserve { get; }

        bool IsComplete { get; }
    }

    public interface IDrivingInformationDisplay // car #2
    {
        int ActualSpeed { get; }
    }

    public interface IDrivingProcessor // car #2
    {
        int ActualSpeed { get; }

        void IncreaseSpeedTo(int speed);

        void ReduceSpeed(int speed);
    }
    public class Car : ICar
    {
        public IFuelTankDisplay fuelTankDisplay;

        private IEngine engine;

        private IFuelTank fuelTank;

        public bool EngineIsRunning { get; private set; }

        public IDrivingInformationDisplay drivingInformationDisplay; // car #2  

        private IDrivingProcessor drivingProcessor; // car #2

        public Car() : this(20)
        { }

        public Car(double fuelLevel)
        {
            EngineIsRunning = false;
            this.engine = new Engine();
            this.drivingProcessor = new DrivingProcessor(0, 10);
            this.drivingInformationDisplay = new DrivingInformationDisplay((DrivingProcessor)drivingProcessor);
            this.fuelTank = new FuelTank(fuelLevel);
            this.fuelTankDisplay = new FuelTankDisplay((FuelTank)fuelTank);
        }

        public Car(double fuelLevel, int maxAcceleration) // car #2
        {
            if (maxAcceleration <= 5)
                maxAcceleration = 5;
            if (maxAcceleration >= 20)
                maxAcceleration = 20;

            EngineIsRunning = false;
            this.engine = new Engine();
            this.drivingProcessor = new DrivingProcessor(0, maxAcceleration);
            this.drivingInformationDisplay = new DrivingInformationDisplay((DrivingProcessor)drivingProcessor);
            this.fuelTank = new FuelTank(fuelLevel);
            this.fuelTankDisplay = new FuelTankDisplay((FuelTank)fuelTank);

        }

        public void EngineStart()
        {
            if (fuelTank.FillLevel > 0)
                EngineIsRunning = true;
        }

        public void EngineStop()
        {
            EngineIsRunning = false;
        }

        public void Refuel(double liters)
        {
            fuelTank.Refuel(liters);
        }

        public void RunningIdle()
        {
            if (EngineIsRunning)
            {
                fuelTank.Consume(0.0003);
            }
            if (fuelTank.FillLevel == 0)
            {
                EngineStop();
            }
        }

        public void BrakeBy(int speed) // car #2
        {

            if (speed < 0)
            {
                this.FreeWheel();
                return;
            }
            if (drivingInformationDisplay.ActualSpeed - speed < 0)
            {
                this.FreeWheel();
                return;
            }
            drivingProcessor.ReduceSpeed(speed);
        }

        public void Accelerate(int speed) // car #2
        {

            if (EngineIsRunning == false)
            {
                return;
            }

            if (drivingInformationDisplay.ActualSpeed > speed)
            {
                this.FreeWheel();
                return;
            }
            drivingProcessor.IncreaseSpeedTo(speed);

            int a = drivingInformationDisplay.ActualSpeed;

            if (a >= 1 && a <= 60)
                fuelTank.Consume(0.0020);
            if (a >= 61 && a <= 100)
                fuelTank.Consume(0.0014);
            if (a >= 101 && a <= 140)
                fuelTank.Consume(0.0020);
            if (a >= 141 && a <= 200)
                fuelTank.Consume(0.0025);
            if (a >= 201 && a <= 250)
                fuelTank.Consume(0.0030);

            if (fuelTank.FillLevel == 0)
            {
                EngineStop();
            }

        }
        public void FreeWheel() // car #2
        {
            drivingProcessor.ReduceSpeed(1);
            //this.RunningIdle();
            fuelTank.Consume(0.0003);


        }
    }

    public class DrivingInformationDisplay : IDrivingInformationDisplay // car #2
    {

        DrivingProcessor drivingProcessor = null;

        public DrivingInformationDisplay(DrivingProcessor drivingProcessor)
        {
            this.drivingProcessor = drivingProcessor;
        }
        public int ActualSpeed
        {
            get
            {
                return drivingProcessor.ActualSpeed;
            }
        }
    }

    public class DrivingProcessor : IDrivingProcessor // car #2
    {
        public int ActualSpeed { get; set; }
        public int maxAcceleration { get; }
        public DrivingProcessor(int ActualSpeed, int maxAcceleration)
        {
            this.ActualSpeed = ActualSpeed;
            this.maxAcceleration = maxAcceleration;
        }
        public void IncreaseSpeedTo(int speed)
        {

            if (speed <= 250 && speed >= 0)
            {
                if (speed - ActualSpeed <= maxAcceleration)
                {
                    ActualSpeed = speed;
                }
                else
                    //if (speed - ActualSpeed > 10)
                    ActualSpeed += maxAcceleration;
            }
            else if (speed >= 250 && speed >= 0)
                ActualSpeed = 250;
        }

        public void ReduceSpeed(int speed)
        {
            if (speed <= 10 && speed >= 0)
            {
                ActualSpeed -= speed;
            }
            if (speed > 10)
                ActualSpeed -= 10;

            if (ActualSpeed < 0)
            {
                ActualSpeed = 0;
            }
        }
    }

    public class Engine : IEngine
    {
        public bool IsRunning { get; }
        public void Consume(double liters)
        {

        }
        public void Start()
        {

        }
        public void Stop()
        {

        }
    }

    public class FuelTank : IFuelTank
    {
        public double FillLevel { get; set; }

        public FuelTank(double fillLevel)
        {

            if (fillLevel >= 0)
            {
                if (fillLevel > 60)
                {
                    FillLevel = 60;
                }
                else
                {
                    FillLevel = fillLevel;
                }
            }
            else
            {
                FillLevel = 0;
            }

        }
        public bool IsOnReserve
        {
            get
            {
                if (FillLevel < 5)
                {
                    return true;
                }
                return false;
            }
        }

        public bool IsComplete
        {
            get
            {
                if (this.FillLevel >= 60)
                {
                    return true;
                }
                return false;
            }

        }

        public void Consume(double liters)
        {
            if ((FillLevel - liters) >= 0)
            {
                FillLevel -= liters;
            }
            else
            {
                FillLevel = 0;
            }
        }

        public void Refuel(double liters)
        {
            if ((FillLevel + liters) <= 60)
            {
                FillLevel += liters;
            }
            else
            {
                FillLevel = 60;
            }
        }
    }

    public class FuelTankDisplay : IFuelTankDisplay
    {
        private FuelTank fuelTank = null;

        public FuelTankDisplay(FuelTank fuelTank)
        {
            this.fuelTank = fuelTank;
        }
        public double FillLevel
        {
            get
            {

                return Math.Round(fuelTank.FillLevel, 2);
            }
        }

        public bool IsOnReserve
        {
            get
            {
                return fuelTank.IsOnReserve;
            }
        }

        public bool IsComplete
        {
            get
            {
                return fuelTank.IsComplete;
            }
        }
    }
}
