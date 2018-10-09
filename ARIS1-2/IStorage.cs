using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ARIS1_2
{
    class IStorage
    {
        List<Clinic> clinics = new List<Clinic>();

        public IClinicReader Reader { get; set; }
        public IClinicBinder Binder { get; set; }
        public IClinicValidator Validator { get; set; }
        public IClinicSaver Saver { get; set; }

        public IStorage(IClinicReader reader, IClinicBinder binder, IClinicValidator validator, IClinicSaver saver)
        {
            this.Reader = reader;
            this.Binder = binder;
            this.Validator = validator;
            this.Saver = Saver;
        }

        public void Process()
        {
            string[] data = Reader.GetInputData();
            Clinic clinic = Binder.CreateClinic(data);
            if (Validator.IsValid(clinic))
            {
                clinics.Add(clinic);
                Saver.Save(clinic, "output.txt");
                Console.WriteLine("Данные успешно обработаны");
            }
            else
            {
                Console.WriteLine("Некорректные данные");
            }
        }
    }
}
