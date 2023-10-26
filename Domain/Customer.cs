namespace Domain
{
    public class Customer
    {
        public string Name { get; set; }
        public string NationalCode { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Shaba { get; set; }

        private Customer()
        {

        }

        public static Customer Create(
            string name,
            string nationalCode,
            string phone,
            string mobile,
            string shaba)
        {
            CheckNameRules(name);

            CheckNationalCodeRules(nationalCode);

            CheckMobileRules(mobile);

            CheckPhoneRules(phone);

            CheckShabaRules(shaba);

            return new Customer
            {
                Mobile = mobile,
                Name = name,
                NationalCode = nationalCode,
                Phone = phone,
                Shaba = shaba
            };
        }

        private static void CheckNameRules(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
        }

        private static void CheckPhoneRules(string phone)
        {
            if (string.IsNullOrEmpty(phone))
                throw new ArgumentNullException(nameof(phone));

            if (!IsValidPhoneNumber(phone))
                throw new InvalidDataException("phone is invalid");
        }

        private static void CheckShabaRules(string shaba)
        {
            if (string.IsNullOrEmpty(shaba))
                throw new ArgumentNullException(nameof(shaba));

            if (shaba.Trim().Length != 24)
                throw new InvalidDataException("shaba len is invalid");

            if (!shaba.Trim().ToLower().StartsWith("ir"))
                throw new InvalidDataException("shaba is invalid");
        }

        private static void CheckNationalCodeRules(string nationalCode)
        {
            if (string.IsNullOrEmpty(nationalCode))
                throw new ArgumentNullException(nameof(nationalCode));

            if (!IsValidNationalCodeNumber(nationalCode))
                throw new InvalidDataException("national code is invalid");

            if (nationalCode.Trim().Length != 10)
                throw new InvalidDataException("national code len is invalid");
        }

        private static void CheckMobileRules(string mobile)
        {
            if (string.IsNullOrEmpty(mobile))
                throw new ArgumentNullException(nameof(mobile));

            if (mobile.Trim().Length != 11)
                throw new InvalidDataException("mobile len is invalid");

            if (!IsValidMobileNumber(mobile))
                throw new InvalidDataException("mobile is invalid");
        }

        private static bool IsValidNationalCodeNumber(string nationalCode)
        {
            return long.TryParse(nationalCode, out _);
        }

        private static bool IsValidMobileNumber(string mobile)
        {
            return long.TryParse(mobile, out _);
        }

        private static bool IsValidPhoneNumber(string phone)
        {
            return long.TryParse(phone, out _);
        }
    }
}


