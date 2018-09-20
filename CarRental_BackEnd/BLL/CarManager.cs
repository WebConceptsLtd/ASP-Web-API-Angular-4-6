using BO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class CarManager: DALBase
    {
        public List<CarModel> GetAllCars()
        {
            return db.Cars.Select(b => new CarModel
            {
                CarID=b.CarID,
                BarnchID=b.BranchID,
                CarTypeID=b.CarTypeID,
                KM = b.KM,
                CarPic = b.CarPic,
                IsFix = b.IsFix,
                IsAvailable = b.IsAvailable,
                CarNum = b.CarNum,

                CarType = new CarTypeModel
                {
                    Brand = b.CarType.Brand,
                    Model = b.CarType.Model,
                    PricePerDay = b.CarType.PricePerDay,
                    PriceExtraPerDay = b.CarType.PriceExtraPerDay,
                    Year = b.CarType.Year,
                    IsManual = b.CarType.IsManual
                },
                Branch = new BranchModel
                {
                    Name = b.Branch.Name,
                    Address = b.Branch.Address

                }
            }).ToList();

        }
        public CarModel GetACar(int id)
        {
            Car car = db.Cars.FirstOrDefault(b => b.CarID == id);

            if (car != null)
            {
                return new CarModel
                {
                    CarID=car.CarID,
                    CarTypeID =car.CarTypeID,
                    BarnchID=car.BranchID,
                    CarNum = car.CarNum,
                    CarPic = car.CarPic,
                    KM = car.KM,
                    IsAvailable = car.IsAvailable,
                    IsFix = car.IsFix,
                    CarType = new CarTypeModel
                    {
                        Brand = car.CarType.Brand,
                        Model = car.CarType.Model,
                        IsManual = car.CarType.IsManual,
                        PriceExtraPerDay = car.CarType.PriceExtraPerDay,
                        PricePerDay = car.CarType.PricePerDay,
                        Year = car.CarType.Year
                    },
                    Branch = new BranchModel
                    {
                        Name=car.Branch.Name,
                        Address=car.Branch.Address
                        
                    }
                };
            }
            return null;
        }


        public bool AddCar(CarModel car)
        {
            try { 
            using (CarRentalEntities db = new CarRentalEntities())
            {
                Car c = db.Cars.Where(a => car.CarID == a.CarID).FirstOrDefault();
                if (c != null)
                {
                    return false;
                }

            };

            db.Cars.Add(new Car
            {
                CarNum = car.CarNum,
                CarPic = car.CarPic,
                KM = car.KM,
                IsAvailable = car.IsAvailable,
                IsFix = car.IsFix,
                CarType = new CarType
                {
                    Brand = car.CarType.Brand,
                    Model = car.CarType.Model,
                    IsManual = car.CarType.IsManual,
                    PriceExtraPerDay = car.CarType.PriceExtraPerDay,
                    PricePerDay = car.CarType.PricePerDay,
                    Year = car.CarType.Year
                },
                Branch = new Branch
                {

                    Name = car.Branch.Name,
                    Address = car.Branch.Address,
                    Latitude = car.Branch.Latitude,
                    Longtitude = car.Branch.Longtitude

                }
            });

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteCar(int id)
        {
            try
            {
                Car d = db.Cars.Where(bc => bc.CarID == id).FirstOrDefault();
                if (d != null)
                {
                    db.Cars.Remove(d);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool EditCar(CarModel b)
        {
            using (CarRentalEntities db = new CarRentalEntities())
            {
                try
                {
                    Car bk = db.Cars.FirstOrDefault(Car => Car.CarNum == b.CarNum);
                    if (bk != null)
                    {
                        bk.IsAvailable = b.IsAvailable;
                        bk.CarID = b.CarID;
                        bk.KM = b.KM;
                        bk.IsFix = b.IsFix;


                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }

            }
        }

    }
}

