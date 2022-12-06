using System.Linq;

namespace GolfApp.Models
{
    public class EFShaftRepository : IShaftRepository
    {
        private ShaftDbContext _context { get; set; }

        public EFShaftRepository(ShaftDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Shaft> shafts => _context.shaft;
        public IQueryable<Brand> brands => _context.brand;
        public IQueryable<AdapterSettings> adapterSettings => _context.adapterSettings;
        public IQueryable<BuildType> buildTypes => _context.buildType;
        public IQueryable<GripModel> gripModels => _context.gripModel;
        public IQueryable<ModelFlex> modelFlexes => _context.modelFlex;

        public int GetMaxID(string x)
        {
            var maxID = 0;

            try
            {
                switch (x)
                {
                    case "shaft":
                        maxID = _context.shaft.Max(x => x.shaftID);
                        break;
                    case "brand":
                        maxID = _context.brand.Max(x => x.brandID);
                        break;
                    case "adapterSetting":
                        maxID = _context.adapterSettings.Max(x => x.adapterID);
                        break;
                    case "buildType":
                        maxID = _context.buildType.Max(x => x.typeID);
                        break;
                    case "grip":
                        maxID = _context.gripModel.Max(x => x.gripID);
                        break;
                    case "modelFlex":
                        maxID = _context.modelFlex.Max(x => x.modelFlexID);
                        break;
                }
            }
            catch
            {

            }

            return maxID;
        }
        public void CreateShaft(Shaft s)
        {
            _context.Add(s);
            _context.SaveChanges();
        }

        public void CreateBrand(Brand b)
        {
            _context.Add(b);
            _context.SaveChanges();
        }

        public void CreateAdapterSettings(AdapterSettings a)
        {
            _context.Add(a);
            _context.SaveChanges();
        }

        public void CreateBuildType(BuildType b)
        {
            _context.Add(b);
            _context.SaveChanges();
        }

        public void CreateGripModel(GripModel g)
        {
            _context.Add(g);
            _context.SaveChanges();
        }

        public void CreateModelFlex(ModelFlex m)
        {
            _context.Add(m);
            _context.SaveChanges();
        }

        public void SaveShaft(Shaft s)
        {
            _context.Update(s);
            _context.SaveChanges();
        }

        public void SaveBrand(Brand b)
        {
            _context.Update(b);
            _context.SaveChanges();
        }

        public void SaveAdapterSettings(AdapterSettings a)
        {
            _context.Update(a);
            _context.SaveChanges();
        }

        public void SaveBuildType(BuildType b)
        {
            _context.Update(b);
            _context.SaveChanges();
        }

        public void SaveGripModel(GripModel g)
        {
            _context.Update(g);
            _context.SaveChanges();
        }

        public void SaveModelFlex(ModelFlex m)
        {
            _context.Update(m);
            _context.SaveChanges();
        }

        public void DeleteShaft(Shaft s)
        {
            _context.shaft.Remove(s);
            _context.SaveChanges();
        }

        public void DeleteBrand(Brand b)
        {
            _context.brand.Remove(b);
            _context.SaveChanges();
        }

        public void DeleteAdapterSettings(AdapterSettings a)
        {
            _context.adapterSettings.Remove(a);
            _context.SaveChanges();
        }

        public void DeleteBuildType(BuildType b)
        {
            _context.buildType.Remove(b);
            _context.SaveChanges();
        }

        public void DeleteGripModel(GripModel g)
        {
            _context.gripModel.Remove(g);
            _context.SaveChanges();
        }

        public void DeleteModelFlex(ModelFlex m)
        {
            _context.modelFlex.Remove(m);
            _context.SaveChanges();
        }

    }
}
