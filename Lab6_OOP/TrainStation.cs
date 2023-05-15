using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_OOP
{
    public class TrainStation : AbsctructTrainStation
    {
        /// <summary>
        /// Конструктор, который наследует конструктор из наследуемого класса с одним параметром
        /// </summary>
        /// <param name="stationName"></param>
        public TrainStation(string? stationName) : base("Стояночная станция", stationName)
        {
        }
        /// <summary>
        /// Конструктор, который наследует конструктор из наследуемого класса без параметра
        /// </summary>
        public TrainStation() : base()
        {
        }
        /// <summary>
        /// Возвращает сообщение о прибытие поезда
        /// </summary>
        /// <returns></returns>
        public override string ArriveTrain()
        {
            return "поезд прибыл на станцию";
        }
        /// <summary>
        /// Возвращает сообщение о убытие поезда
        /// </summary>
        /// <returns></returns>
        public override string DepartTrain()
        {
            return "поезд отправлен со станции";
        }
    }
}
