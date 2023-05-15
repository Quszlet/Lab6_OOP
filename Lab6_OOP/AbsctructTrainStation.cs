using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_OOP
{
    public abstract class AbsctructTrainStation
    {
        /// <summary>
        /// Имя станции
        /// </summary>
        public string? NameStation { get; set; }
        /// <summary>
        /// Тип станции
        /// </summary>
        public string? TypeStation { get; set; }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="typeStation"></param>
        /// <param name="nameStation"></param>
        public AbsctructTrainStation(string? typeStation, string? nameStation)
        {
            TypeStation = typeStation;
            NameStation = nameStation;
        }
        /// <summary>
        /// Конструктур без параметров
        /// </summary>
        public AbsctructTrainStation()
        {
            TypeStation = "";
            NameStation = "";
        }
        /// <summary>
        /// Конструктор с одним параметром
        /// </summary>
        /// <param name="typeStation"></param>
        public AbsctructTrainStation(string? typeStation)
        {
            TypeStation = typeStation;
        }
        /// <summary>
        /// Абстрактный метод, который должен возвращать сообщение о прибытие поезда
        /// </summary>
        /// <returns></returns>
        public abstract string ArriveTrain();
        /// <summary>
        /// Абстрактный метод, который должен возвращать сообщение о убытии поезда
        /// </summary>
        /// <returns></returns>
        public abstract string DepartTrain();
    }
}
