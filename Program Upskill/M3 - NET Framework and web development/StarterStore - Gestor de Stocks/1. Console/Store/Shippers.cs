namespace Store
{
    class Shippers : Company
    {
        public static int shippersID;
        public string ID { get; set; }
        public string companyType{ get; set; }

        public Shippers(string fullName, string address, string city, string postalCode, string country, string phone, string NIF) : base(fullName,
                        address, city, postalCode, country, phone, NIF)
        {
            this.ID = "SH" + GetNextID();
            this.companyType = "Shipper";
        }

        static Shippers() => shippersID = 2020000;
        protected int GetNextID() => ++shippersID;

        public override string ReadCompany() //Descrição da transportadora
        {
            return $"ID: {ID} - {fullName} - {companyType}  \nMorada: {address}, {city}, {postalCode}, {country} \nContacto:{phone} NIF: {NIF}";       
        }    
   }
}