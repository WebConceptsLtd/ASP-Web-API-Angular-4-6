using BO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OrderManager : DALBase
    {
        //private readonly CarRentalEntities db = new CarRentalEntities();

        public double GetFinalPrice(Order order, CarType car)
        {
            decimal price = 0;

            if (order.Returned >= order.FinishDate)
            {
                var extra = Math.Abs(order.FinishDate.Subtract((DateTime)order.Returned).Days);
                ///int PriceExtraPerDay = 0;
                price = extra * car.PriceExtraPerDay;
            }

            var result = order.FinishDate.Subtract(order.StartDate).Days;
            //int PricePerDay = 0;
            price += result * car.PricePerDay;
            return Convert.ToDouble(price);

        }
        //Is the car available
        private bool IsAvail(int carId)
        {
            Car Car = db.Cars.FirstOrDefault(at => at.CarID == carId);

            if (Car != null)
                return Car.IsAvailable;
            else
                return false;
        }
       
        public bool MakeOrder(OrderModel order)
        {
            try
            {
                Order c = db.Orders.Where(x => order.OrderID == x.OrderID).FirstOrDefault();
                if (c != null)
                {
                    return false;
                }

                db.Orders.Add(new Order
                {
                    OrderID = order.OrderID,
                    StartDate = order.StartDate,
                    FinishDate = order.FinishDate,

                    //Returned = order.Returned,
                    CarID = order.CarID,
                    UserID = order.UserID,
                   // Car = new Car
                    //{
                        //CarNum = order.Car.CarNum,
                        //IsFix = order.Car.IsFix,
                        //IsAvailable = order.Car.IsAvailable,
                        //CarID = order.Car.CarID,
                        //KM = order.Car.KM,
                       // CarPic = order.Car.CarPic,
                        //Branch = new Branch
                        //{
                        //    Name = order.Car.Branch.Name,
                            //Address = order.Car.Branch.Address,
                            //Longtitude = order.Car.Branch.Longtitude,
                            //Latitude = order.Car.Branch.Latitude,

                        //},
                    //    CarType = new CarType
                    //    {
                    //        CarTypeID = order.Car.CarTypeID,
                    //        Brand = order.Car.CarType.Brand,
                    //        Model = order.Car.CarType.Model,
                    //        PricePerDay = order.Car.CarType.PricePerDay,
                    //        PriceExtraPerDay = order.Car.CarType.PriceExtraPerDay,
                    //        Year = order.Car.CarType.Year,
                    //        IsManual = order.Car.CarType.IsManual
                    //    },
                    //},
                    //User = new User
                    //{
                    //    FullName = order.User.FullName,
                    //    Birthday = order.User.Birthday,
                    //    UserName = order.User.UserName,
                    //    Gender = order.User.Gender,
                    //    Email = order.User.Email,
                    //    Phone = order.User.Phone,
                    //    PicPath = order.User.PicPath
                    //}
                });
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //public static class DateTimeExtensionMethods
        //{
        //    public static string ToString(this DateTime? retuned, string format)
        //    {
        //        if (retuned == null)
        //            return string.Empty;

        //        return retuned.Value.ToString(format);
        //    }
        //}
        static void Test(DateTime? value)
        {
            //
            // This method uses the HasValue property.
            // ... If there is no value, the number zero is written.
            //
            if (value.HasValue)
            {
                Console.WriteLine(value.Value);
            }
            else
            {
                Console.WriteLine(0);
            }
        }
        public List<OrderModel> GetOrders()
        {
            return db.Orders.Select(a => new OrderModel
            {
                OrderID = a.OrderID,
                StartDate = a.StartDate,
                Returned = a.Returned,
                FinishDate = a.FinishDate,
                UserID = a.UserID,
                CarID = a.CarID,
                Car = new CarModel
                {
                    CarNum = a.Car.CarNum,
                    IsFix = a.Car.IsFix,
                    IsAvailable = a.Car.IsAvailable,
                    CarID = a.Car.CarID,
                    KM = a.Car.KM,
                    CarPic = a.Car.CarPic,
                    Branch = new BranchModel
                    {
                        Name = a.Car.Branch.Name,
                        Address = a.Car.Branch.Address,
                        Longtitude = a.Car.Branch.Longtitude,
                        Latitude = a.Car.Branch.Latitude,

                    },
                    CarType = new CarTypeModel
                    {
                        CarTypeID = a.Car.CarTypeID,
                        Brand = a.Car.CarType.Brand,
                        Model = a.Car.CarType.Model,
                        PricePerDay = a.Car.CarType.PricePerDay,
                        PriceExtraPerDay = a.Car.CarType.PriceExtraPerDay,
                        Year = a.Car.CarType.Year,
                        IsManual = a.Car.CarType.IsManual
                    },
                },
                User = new UserModel
                {
                    FullName = a.User.FullName,
                    Birthday = a.User.Birthday,
                    UserName = a.User.UserName,
                    Gender = a.User.Gender,
                    Email = a.User.Email,
                    Phone = a.User.Phone,
                    PicPath = a.User.PicPath
                }
            }).ToList();
        }
        public OrderModel OrderACar(int id)
        {
            Order o = db.Orders.FirstOrDefault(b => b.CarID == id);

            if (o != null)
            {
                return new OrderModel
                {
                    StartDate = o.StartDate,
                    FinishDate = o.FinishDate,
                    Returned = o.Returned,
                    UserID = o.UserID,
                    CarID = o.CarID,

                    Car = new CarModel
                    {
                        CarNum = o.Car.CarNum,
                        KM = o.Car.KM,

                        Branch = new BranchModel
                        {
                            Name = o.Car.Branch.Name,
                            Address = o.Car.Branch.Address
                        },
                        CarType = new CarTypeModel
                        {
                            Brand = o.Car.CarType.Brand,
                            Model = o.Car.CarType.Model,
                            PricePerDay = o.Car.CarType.PricePerDay,
                            PriceExtraPerDay = o.Car.CarType.PriceExtraPerDay,
                            IsManual = o.Car.CarType.IsManual,
                            Year = o.Car.CarType.Year,
                            CarTypeID = o.Car.CarType.CarTypeID
                        },
                    },
                    User = new UserModel
                    {
                        UserTypeID = o.User.UserTypeID,
                        Email = o.User.Email,
                        UserName = o.User.UserName
                    }

                };




            }
            return null;
        }
        public OrderModel GetOneOrder(int orderID)
        {
            var query = from o in db.Orders
                        where o.OrderID == orderID
                        select new OrderModel
                        {
                            StartDate = o.StartDate,
                            FinishDate = o.FinishDate,
                            Returned = o.Returned,
                            UserID = o.UserID,
                            CarID = o.CarID,
                            Car = new CarModel
                            {
                                CarNum = o.Car.CarNum,
                                CarPic = o.Car.CarPic,

                                Branch = new BranchModel
                                {
                                    Name = o.Car.Branch.Name

                                },
                                CarType = new CarTypeModel
                                {
                                    Brand = o.Car.CarType.Brand,
                                    Model = o.Car.CarType.Model,
                                    PricePerDay = o.Car.CarType.PricePerDay,
                                    PriceExtraPerDay = o.Car.CarType.PriceExtraPerDay,

                                },
                            },
                            User = new UserModel
                            {
                                FullName = o.User.FullName,
                                UserName = o.User.UserName
                            }

                        };

            return query.SingleOrDefault();


        }

        public OrderModel UpdateOrder(OrderModel orderModel)
        {
            var query = from o in db.Orders

                        select o;

            Order order = query.FirstOrDefault();
            if (order == null)
                return null;

            order.StartDate = orderModel.StartDate;
            order.FinishDate = orderModel.FinishDate;
            order.Returned = orderModel.Returned;
            order.User = order.User;
            order.Car = order.Car;
            db.SaveChanges();

            return orderModel;
        }
        public bool DeleteOrder(int ordid)
        {
            try
            {
                using (CarRentalEntities db = new CarRentalEntities())
                {
                    Order b = db.Orders.FirstOrDefault(bk => bk.OrderID == ordid);
                    if (b != null)
                    {
                        db.Orders.Remove(b);
                        db.SaveChanges();
                        return true;
                    }
                }
                return false;

            }
            catch (Exception)
            {
                return false;
            }



        }
        public Order UpdateOrderDate(Order orderModel)
        {
            var query = from o in db.Orders

                        select o;

            Order order = query.SingleOrDefault();
            if (order == null)
                return null;

            order.StartDate = orderModel.StartDate;

            db.SaveChanges();

            return orderModel;
        }


    }

}
