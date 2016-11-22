using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippoTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            APIResource resource = new APIResource(“< Your Shippo Token >“);

            // Hash table of properties
            Hashtable parameters = new Hashtable();
            parameters.Add("length", "5");
            parameters.Add("width", "5");
            parameters.Add("height", "5");
            parameters.Add("distance_unit", "cm");
            parameters.Add("weight", "2");
            parameters.Add("mass_unit", "lb");
            parameters.Add("template", "");
            parameters.Add("metadata", "Customer ID 123456");

            // Create Parcel
            Parcel parcel = resource.CreateParcel(parameters);
            Console.WriteLine(parcel.Length);

            // Get Parcel
            Parcel parcelRetrieved = resource.RetrieveParcel((string)parcel.ObjectId);
            Console.WriteLine(parcelRetrieved.DistanceUnit);

            // All Parcels
            parameters = new Hashtable();
            parameters.Add("results", "2");
            parameters.Add("page", "1");

            var parcels = resource.AllParcels(parameters);
            Console.WriteLine(parcels.Data.Count);
        }
    }
}
