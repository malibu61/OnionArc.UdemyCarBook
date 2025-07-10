using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.CarFeatureDtos
{
    public class ResultCarFeatureByCarIdDto
    {
        public int CarFeatureID { get; set; }
        public int FeatureID { get; set; }
        public int CarID { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string FeatureName { get; set; }
        public bool Available { get; set; }


        //public class Rootobject
        //{
        //    public Result[] result { get; set; }
        //    public int id { get; set; }
        //    public object exception { get; set; }
        //    public int status { get; set; }
        //    public bool isCanceled { get; set; }
        //    public bool isCompleted { get; set; }
        //    public bool isCompletedSuccessfully { get; set; }
        //    public int creationOptions { get; set; }
        //    public object asyncState { get; set; }
        //    public bool isFaulted { get; set; }
        //}

        //public class Result
        //{
        //    public int carFeatureID { get; set; }
        //    public int featureID { get; set; }
        //    public int carID { get; set; }
        //    public string carName { get; set; }
        //    public string brandName { get; set; }
        //    public string featureName { get; set; }
        //    public bool available { get; set; }
        //}

    }
}
