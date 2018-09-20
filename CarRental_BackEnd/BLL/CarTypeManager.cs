using BO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CarTypeManager : DALBase

    {
        // protected CarRentalEntities db = new CarRentalEntities();

        public List<CarTypeModel> GetListOftype()
        {
            return db.CarTypes.Select(b => new CarTypeModel
            {
                CarTypeID = b.CarTypeID,
                Brand = b.Brand,
                Model = b.Model,
                PricePerDay = b.PricePerDay,
                PriceExtraPerDay = b.PriceExtraPerDay,
                Year = b.Year,
                IsManual = b.IsManual

            }).ToList();

        }
        //brand list
        public List<string> GetListOfBrand()
        {

            return db.CarTypes.Select(a => a.Brand).ToList();
        }
        //model list
        public List<string> GetListOfModel()
        {

            return db.CarTypes.Select(a => a.Model).ToList();
        }

        //add car type
        public bool AddCarType(CarTypeModel cars)
        {
            try
            {
                CarType ct = db.CarTypes.Where(a => cars.CarTypeID == a.CarTypeID).FirstOrDefault();
                if (ct != null)
                {
                    return false;
                }
                db.CarTypes.Add(new CarType
                {
                    CarTypeID = cars.CarTypeID,
                    Brand = cars.Brand,
                    Model = cars.Model,
                    PricePerDay = cars.PricePerDay,
                    PriceExtraPerDay = cars.PriceExtraPerDay,
                    Year = cars.Year,
                    IsManual = cars.IsManual,

                });

                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public CarTypeModel GetACar(int id)
        {
            CarType car = db.CarTypes.FirstOrDefault(b => b.CarTypeID == id);

            if (car != null)
            {
                return new CarTypeModel
                {
                    Brand = car.Brand,
                    Model = car.Model,
                    IsManual = car.IsManual,
                    PriceExtraPerDay = car.PriceExtraPerDay,
                    PricePerDay = car.PricePerDay,
                    Year = car.Year,
                    Car = new CarModel()
                    {

                        Branch = new BranchModel()
                        {

                        }
                    }
                };
            }
            return null;
        }
        //update cartype
        public CarTypeModel UpdateCarType(CarTypeModel ctm)
        {
            var query = from o in db.CarTypes

                        select o;

            CarType ct = query.FirstOrDefault();
            if (ct == null)
                return null;

            ct.Brand = ctm.Brand;
            ct.Model = ctm.Model;
            ct.PricePerDay = ctm.PricePerDay;
            ct.PriceExtraPerDay = ctm.PriceExtraPerDay;
            ct.Year = ctm.Year;
            ct.IsManual = ctm.IsManual;
            db.SaveChanges();

            return ctm;
        }
        //// /delete car

        public bool DeleteCarType(int id)
        {
            try
            {
                CarType a = db.CarTypes.Where(b => b.CarTypeID == id).FirstOrDefault();
                if (a != null)
                {
                    db.CarTypes.Remove(a);
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
        // car type model

        //public CarTypeModel GetCarType(string model)
        //{
        //    using (CarRentalEntities db = new CarRentalEntities())
        //    {
        //        CarType b = db.CarTypes.FirstOrDefault(at => at.Model == model);

        //        if (b != null)
        //        {
        //            return new CarTypeModel
        //            {
        //                Brand = b.Brand,
        //                Model = b.Model,
        //                PricePerDay = b.PricePerDay,
        //                PriceExtraPerDay = b.PriceExtraPerDay,
        //                Year = b.Year,
        //                IsManual = b.IsManual
        //            };
        //        }

        //        return null;
        //    }
        //}
    }
}

