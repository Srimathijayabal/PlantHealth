using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantHealth.Config
{
    public static class URLs
    {
        public const string StartPageURL = "https://phi-frontend.test.cdp-int.defra.cloud";
        public const string PurposePage = StartPageURL + "/plant-health";
        public const string PlantImportPage = PurposePage + "/purpose-of-visit?whatdoyouwanttofind=importrules";
        public const string SearchPage = PurposePage + "/import-confirmation?whereareyouimportinginto=gb";
        public const string CountryPage = "https://phi-frontend.test.cdp-int.defra.cloud/plant-health/search?searchQuery=abies+alba+%28Fir%2C+European+silver%3B+Pine%2C+Swiss%29&hostRef=29&eppoCode=ABIAL";
        public const string FormatPage = "https://phi-frontend.test.cdp-int.defra.cloud/plant-health/country-search?countrySearchQuery=India&emptyCountrySearchQuery=false";


    }
}
