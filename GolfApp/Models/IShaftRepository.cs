using System.Linq;

namespace GolfApp.Models
{
    public interface IShaftRepository
    {
        IQueryable<Shaft> shafts { get; }
        IQueryable<Brand> brands { get; }
        IQueryable<AdapterSettings> adapterSettings { get; }
        IQueryable<BuildType> buildTypes { get; }
        IQueryable<GripModel> gripModels { get; }
        IQueryable<ModelFlex> modelFlexes { get; }

        public void CreateShaft(Shaft s);
        public void CreateBrand(Brand b);
        public void CreateAdapterSettings(AdapterSettings a);
        public void CreateBuildType(BuildType b);
        public void CreateGripModel(GripModel g);
        public void CreateModelFlex(ModelFlex m);




        public void SaveShaft(Shaft s);
        public void SaveBrand(Brand b);
        public void SaveAdapterSettings(AdapterSettings a);
        public void SaveBuildType(BuildType b);
        public void SaveGripModel(GripModel g);
        public void SaveModelFlex(ModelFlex m);




        public void DeleteShaft(Shaft s);
        public void DeleteBrand(Brand b);
        public void DeleteAdapterSettings(AdapterSettings a);
        public void DeleteBuildType(BuildType b);
        public void DeleteGripModel(GripModel g);
        public void DeleteModelFlex(ModelFlex m);




        public int GetMaxID(string x);

    }
}
