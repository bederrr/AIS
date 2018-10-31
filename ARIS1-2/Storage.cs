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
                    if (clinics.Count == 0)
                        tempclinic.ID = 1;
                    else
                        tempclinic.ID = clinics.Last().ID+1;

                    clinics.Add(tempclinic);                //Saver.Save(tempclinics[i], "output.txt");
                    Console.WriteLine("Данные из строки " + (i+1) + " успешно добавлены в коллекцию");
                }
                else
                {
                    Console.WriteLine("Строка " + (i+1) + " содержит некорректные данные");
                }
            }
        }

        public void LoadDB()
        {
            Clinic tempclinic = new Clinic();

            using (UserContext db = new UserContext())
            {
                var clinics = db.Clinics;

                foreach (Clinic u in clinics)
                {
                    tempclinic.ID = u.ID;
                    tempclinic.city = u.city;
                    tempclinic.year = u.year;
                    tempclinic.specialization = u.specialization;
                    tempclinic.cost = u.cost;
                    tempclinic.doctors_count = u.doctors_count;
                    tempclinic.ready = u.ready;
                    clinics.Add(tempclinic);
                    Console.WriteLine("Клиника " + tempclinic.ID + " считана с базы");
                }
            }
        }

        public void UploadProcess()
        {
                Saver.Save(clinics, "file.csv");
        }
    }
}
