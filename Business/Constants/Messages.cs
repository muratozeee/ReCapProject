using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    //we used the static
    //static=no need to use new.it is directly coming...
    //Note=private naming is camelCase,public naming is PascalCase 

    public static class Messages
    {
        //it is static constant
        //also we will use the fluentvalidation but now we are using this type.
        //we will refactor them
        public static string CarAdded = "Car was Added...!";
        public static string CarDeleted = "Car was Deleted...!";
        public static string CarUpdated = "Car was Updated...!";
        public static string CarNameİnvalid = "Wrong Car Name And Daily Price Please Check it..!";
       
        public static string BrandAdded = "Brand was Added...!";
        public static string BrandDeleted = "Brand was Deleted...!";
        public static string BrandUpdated = "Brand was Updated...!";

        public static string ColorAdded = "Color was Added...!";
        public static string ColorDeleted = "Color was Deleted...!";
        public static string ColorUpdated = "Color was Updated...!";
        
        internal static string MaintenanceTime="Maintenance Time..! ";
        
        internal static string CarListed="Car was Listed..!";
        internal static string BrandListed = "Brand was Listed..!";
        internal static string ColorListed = "Color was Listed..!";

        public static string CustomerAdded = "Customer was Added...!";
        public static string CustomerDeleted = "Customer was Deleted...!";
        public static string CustomerUpdated = "Customer was Updated...!";

        public static string UserAdded = "User was Added...!";
        public static string UserDeleted = "User was Deleted...!";
        public static string UserUpdated = "User was Updated...!";

        public static string RentalAdded = "Rental was Added...!";
        public static string RentalDeleted = "Rental was Deleted...!";
        public static string RentalUpdated = "Rental was Updated...!";

        public static string RentalError = "Rental didnt Added..!";

        public static string ImageAdded = "Image was Added..!";

        public static string CarImageLimitReached = "Limit of Car images were Reached..!";
        public static string CarImageAlreadyHave = "This Car Image already have...! You have to Upload different Image";
        public static string CarImageDeleted = "Car Image was Deleted..!";
        public static string ImagesListedById = "Image was Listed by Id";
        public static string ImageUpdated = "Image was Updated..!";
        public static string ImagesListed = "Images were Listed..!";
        public static string ImagesListedByCarId = "Images were Listed By Car ID";
    }
}
