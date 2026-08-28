using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using clsDataAccessLibrary;
using clsUserSessionLibrary;

namespace clsBussinseLibrary
{
    public class clsBCurrencies
    {
        public int ID { set; get; }
        public double SellRate { set; get; }
        public double BuyRate { set; get; }
        public string CountryName { set; get; }
        public string CurrencyName { set; get; }
        public string ImagePath { set; get; }
        public string Code { set; get; }
        public string Capital { set; get; }
        public string PhoneCode { set; get; }
        public string PhoneFormat { set; get; }
        public enum enMode { AddMode, UpdateMode };
        public enMode Mode = enMode.AddMode;

        public clsBCurrencies()
        {
            ID = -1;
            SellRate = -1;
            BuyRate = -1;
            CountryName = "";
            CurrencyName = "";
            ImagePath = "";
            Capital = "";
            Code = "";
            PhoneFormat = "";
            PhoneCode = "";
            Mode = enMode.AddMode;
        }
        public clsBCurrencies(int ID, double SellRate, double BuyRate)
        {
            this.ID = ID;
            this.SellRate = SellRate;
            this.BuyRate = BuyRate;

            Mode = enMode.UpdateMode;
        }
        static public DataTable RetrievDataOfCurrencies()
        {
            return clsCurrencies.RetrievDataOfCurrencies();
        }
        static public DataTable RetreiveCities(int CountryID)
        {
            return clsCurrencies.RetreiveCities(CountryID);
        }

        private bool _AddCurrency()
        {
            return clsCurrencies.AddCurrency(CountryName, Code,PhoneFormat,Capital, PhoneCode, ImagePath, CurrencyName, SellRate, BuyRate);
        }
        private bool _UpdateCurrency()
        {
            return clsCurrencies.UpdateCurrencies(ID, SellRate, BuyRate);
        }
        static public bool DeleteCountries(int ID)
        {
            return clsCurrencies.DeleteCountries(ID);
        }
        static public DataTable RetrieveDataOfCountry()
        {
           return clsCurrencies.RetrieveDataOfCountry();
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddMode:
                    if (_AddCurrency())
                    {
                        Mode = enMode.UpdateMode;
                        return true;
                    }
                    break;
                case enMode.UpdateMode:
                    return !_UpdateCurrency();
            }
            return false;
        }
    }

}
