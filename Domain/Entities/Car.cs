using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities
{
    public class Car : Entity<Guid>
    {
        public Guid ModelId { get; set; }
        public int Kilometer { get; set; }
        public  string  ModelYear{ get; set; }
        public string Plate { get; set; }
        public short MinfindexScore { get; set; }
        public CarState CarState { get; set; }

        public virtual Model? Model { get; set; }
        public Car()
        {
            
        }

        public Car(Guid id,Guid modelId, int kilometer, string modelYear, string plate, short minfindexScore, CarState carState)
        {
            Id = id;
            ModelId = modelId;
            Kilometer = kilometer;
            ModelYear = modelYear;
            Plate = plate;
            MinfindexScore = minfindexScore;
            CarState = carState;
        }
    }
}
