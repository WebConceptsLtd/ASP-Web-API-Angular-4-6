using BO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BranchManager: DALBase
    {

        public List<BranchModel> GetBranches()
        {
            return db.Branches.Select(b => new BranchModel
            {
                BranchID = b.BranchID,
                Name = b.Name,
                Address = b.Address,
                Latitude = b.Latitude,
                Longtitude = b.Longtitude
            }).ToList();

        }

        public List<string> GetBrancheAddress()
        {
            return db.Branches.Select(a => a.Address).ToList();
        }


        public List<string> GetBranchesName()
        {
            return db.Branches.Select(a => a.Name).ToList();
        }

        public BranchModel GetABranch(string name)
        {
            Branch a = db.Branches.FirstOrDefault(at => at.Name == name);

            if (a != null)
            {
                return new BranchModel
                {
                    BranchID = a.BranchID,
                    Name = a.Name,
                    Address = a.Address,
                    Latitude = a.Latitude,
                    Longtitude = a.Longtitude,
                };
            }
            return null;

        }

        public bool AddBranch(BranchModel branch)
        {
            try {
                Branch newbranch = db.Branches.Where(a => a.BranchID == branch.BranchID).FirstOrDefault();
                if (newbranch != null)
                {
                    return false;
                }
                db.Branches.Add(new Branch
                  {
                 BranchID = branch.BranchID,
                Name = branch.Name,
                Address = branch.Address,
                Latitude = branch.Latitude,
                Longtitude = branch.Longtitude,
                  });
               
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public BranchModel UpdateBranch(BranchModel branchModel)
        {
            var query = from o in db.Branches

                        select o;

            Branch b = query.FirstOrDefault();
            if (b == null)
                return null;
            b.Name = branchModel.Name;
            b.Address = branchModel.Address;
            b.Latitude = branchModel.Latitude;
            b.Longtitude = branchModel.Longtitude;

            db.SaveChanges();

            return branchModel;
        }

        public bool DeleteBranch(string name)
        {
            Branch branch = db.Branches.FirstOrDefault(b => b.Name == name);
            if (branch != null)
            {
                db.Branches.Remove(branch);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool EditBranch(BranchModel branchModel)
        {

            Branch branch = db.Branches.FirstOrDefault(b => b.Name == branchModel.Name);
            if (branch != null)
            {
                branch.Address = branchModel.Address;
                db.SaveChanges();
                return true;
            }
            return false;

        }
    }
}

