using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_OOP
{
    public class PassengerTrainStationDecorator : TrainStationDecorator
    {
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="trainStation"></param>
        public PassengerTrainStationDecorator(AbsctructTrainStation trainStation) 
            : base(trainStation, "Пассажирская станция", trainStation.NameStation)
        {
        }
        /// <summary>
        /// Возвращает сообщение о прибытии пассажирского поезда
        /// </summary>
        /// <returns></returns>
        public override string ArriveTrain()
        {
           
            if (trainStation.TypeStation == "Грузовая станция")
            {
                return "пассажирский, " + trainStation.ArriveTrain().ToLower();
            }
            else
            {
                return "пассажирский " + trainStation.ArriveTrain().ToLower();
            }
           
        }
        /// <summary>
        /// Возвращает сообщение о убытии пассажирского поезда
        /// </summary>
        /// <returns></returns>
        public override string DepartTrain()
        {

            if (trainStation.TypeStation == "Грузовая станция")
            {
                return "пассажирский, " + trainStation.DepartTrain().ToLower();
            }
            else
            {
                return "пассажирский " + trainStation.DepartTrain().ToLower();
            }
        }
        /// <summary>
        /// Возвращает сообщение о выполнении проверки билетов пассажиров
        /// </summary>
        /// <returns></returns>
        public string CheckTickets()
        {
            return "билеты пассажиров проверены";
        }
        /// <summary>
        /// Возвращается сообщение о выполнении проверки документов
        /// </summary>
        /// <returns></returns>
        public string CheckDocuments()
        {
            return "документы пассажиров проверены";
        }
    }
}
