using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_OOP
{
    public abstract class TrainStationDecorator : AbsctructTrainStation
    {
        /// <summary>
        /// Объект станции
        /// </summary>
        protected AbsctructTrainStation trainStation;
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="trainStation"></param>
        /// <param name="typeStation"></param>
        /// <param name="nameStation"></param>
        public TrainStationDecorator(AbsctructTrainStation trainStation, string? typeStation, string? nameStation) : base(typeStation, nameStation)
        {
            this.trainStation = trainStation;
        }
    }
}
