using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_OOP
{
    public class CargoTrainStationDecorator : TrainStationDecorator
    {
        /// <summary>
        /// Конструктор, который наследует конструктор класса TrainStationDecorator
        /// </summary>
        /// <param name="trainStation"></param>
        public CargoTrainStationDecorator(AbsctructTrainStation trainStation)
           : base(trainStation,"Грузовая станция", trainStation.NameStation)
        {
        }
        /// <summary>
        /// Возвращает сообщение о прибытие грузового поезда
        /// </summary>
        /// <returns></returns>
        public override string ArriveTrain()
        {
            
                
            if (trainStation.TypeStation == "Пассажирская станция")
            {
                return "грузовой, " + trainStation.ArriveTrain();
            }
            else
            {
                return "грузовой " + trainStation.ArriveTrain();
            }
           
        }
        /// <summary>
        /// Возвращает сообщение о убытии грузового поезда
        /// </summary>
        /// <returns></returns>
        public override string DepartTrain()
        {
           
               
            if (trainStation.TypeStation == "Пассажирская станция")
            {
                return "грузовой, " + trainStation.DepartTrain().ToLower();
            }
            else
            {
                return "грузовой " + trainStation.DepartTrain().ToLower();
            }
            
        }
        /// <summary>
        /// Возвращает сообщение о загрузке груза на поезд
        /// </summary>
        /// <returns></returns>
        public string LoadCargo()
        {
            return "груз загружен на поезд";
        }
        /// <summary>
        /// Возвращает сообщение о выгрузке груза с поезда  
        /// </summary>
        /// <returns></returns>
        public string UnloadCargo()
        {
            return "груз выгружен с поезда";
        }
    }
}
