using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ARIS1_2
{
    class Storage
    {
        public List<Clinic> clinics = new List<Clinic>();

        public IClinicReader Reader { get; set; }
        public IClinicBinder Binder { get; set; }
        public IClinicValidator Validator { get; set; }
        public IClinicSaver Saver { get; set; }

        public Storage(IClinicReader reader, IClinicBinder binder, IClinicValidator validator, IClinicSaver saver)
        {
            this.Reader = reader;
            this.Binder = binder;
            this.Validator = validator;
            this.Saver = saver;
   //         this.Utilites = utilites;
        }

        public void LoadProcess()
        {
            string[] data = Reader.GetInputData();

            Clinic tempclinic = new Clinic();

            for(int i = 0; i<data.Length; i++)
            {
                tempclinic = Binder.CreateClinic(data[i]);

                if (Validator.IsValid(tempclinic))
                {
                    clinics.Add(tempclinic);                //Saver.Save(tempclinics[i], "output.txt");
                    Console.WriteLine("Данные из строки " + (i+1) + " успешно добавлены в коллекцию");
                }
                else
                {
                    Console.WriteLine("Строка " + (i+1) + " содержит некорректные данные");
                }
            }
        }

        public void UploadProcess()
        {
                Saver.Save(clinics, "file.csv");
        }
    }
}
