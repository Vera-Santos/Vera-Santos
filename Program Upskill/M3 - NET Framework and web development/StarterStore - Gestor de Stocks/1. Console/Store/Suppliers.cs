namespace Store
{
    class Suppliers : Company
    {
        public static int suppliersID;
        public string ID { get; set; }
        public string companyType{ get; set; }

        public Suppliers(string fullName, string address, string city, string postalCode, string country, string phone, string NIF) : base(fullName,
                        address, city, postalCode, country, phone, NIF)
        {
            this.ID = "SU" + GetNextID();
            this.companyType = "Supplier";
        }

        static Suppliers() => suppliersID = 2020000;
        protected int GetNextID() => ++suppliersID;

        public override string ReadCompany() //Descrição da transportadora
        {
            return $"ID: {ID} - {fullName} - {companyType}  \nMorada: {address}, {city}, {postalCode}, {country} \nContacto:{phone} NIF: {NIF}";   
        }   
        
    }
}