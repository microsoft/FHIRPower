using FHIRUpload.Models.FHIR;
using FHIRUpload.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FHIRUpload.Controllers
{
    [Route("api/fhir")]
    [ApiController]
    public class FHIRController : Controller
    {
        private readonly IHostingEnvironment _env;
        private const string apptFile = "file.json";
        private ArrayList patientList, practitionerList,scheduleList;

        public FHIRController(IHostingEnvironment env)
        {
            _env = env;
        }

        [HttpGet("upload")]
        public async Task<string> Upload()
        {
            await Patients();
            await Practitioners();
            await Appointments();
            await Schedules();
            await Slots();


            return "Patient, Practitioner, Appointment, Schedule, and Slot data is loaded to FHIR API Server.";
        }

        [HttpGet("cleanup")]
        public async Task<string> Cleanup()
        {
            string json = "";
            json = json+ await RemoveAppointments();
            json = json+ " </br> "+ await RemovePatients();
            json = json+ " </br> "+ await RemovePractitioner();
            json = json + " </br> " + await RemoveSchedules();
            json = json + " </br> " + await RemoveSlots();

            return json;
      //      return "Patient, Practitioner, and Appointment data was deleted from FHIR API Server.";
        }

        [HttpGet("patients")]
        public async Task<Object> GetPatients()
        {
            FHIRService fHIRService = new FHIRService();

          

     

            string json = JsonConvert.SerializeObject(await fHIRService.GetPatients());
            return json;
        }


        [HttpPost("CreatePatients")]
        public async Task<string> Patients()
        {
            string json = "";
            try
            {
                patientList = new ArrayList();
                for (int i = 0; i < 5; i++)
                {
                    string jsonString = ReadFile("patient" + (i + 1 + ".json"));
                    if (string.IsNullOrEmpty(jsonString))
                    {
                        json =  "Patient file not found.";
                    }
                    else
                    {
                        JObject apptObj = JObject.Parse(jsonString);

                        FHIRService fHIRService = new FHIRService();
                        JObject jobj = await fHIRService.CreatePatient(apptObj);
                        string id = (string)jobj["id"];
                        patientList.Add(id);
                        json = JsonConvert.SerializeObject(jobj);
                    }
                }

            }
            catch (Exception ex)
            {

            }


            return json;
        }

        [HttpDelete("RemovePatients")]
        public async Task<string> RemovePatients()
        {
            string json = "<b>Patients with the following ID(s) are deleted: </b>";
            try
            {
                FHIRService fHIRService = new FHIRService();

                JObject jObj = await fHIRService.GetPatients();

                List<Appointment> ApptList = new List<Appointment>();

                var entry = jObj["entry"];
                var count = entry.Count();

                for (int i = 0; i < count; i++)
                {
                   
                    string apptID = (string)entry[i]["resource"]["id"];
                    JsonConvert.SerializeObject(await fHIRService.DeletePatient(apptID));
                    json = json + " </br> " + apptID;
                }

            }
            catch (Exception ex)
            {

            }


            return json;
        }

        [HttpGet("practitioners")]
        public async Task<string> GetPractioner()
        {
            FHIRService fHIRService = new FHIRService();
            string json = JsonConvert.SerializeObject(await fHIRService.GetPractitioner());
            return json;
        }


        [HttpPost("CreatePractitioners")]
        public async Task<string> Practitioners()
        {
            string json = "";
            try
            {
                practitionerList = new ArrayList();
                for (int i = 0; i < 5; i++)
                {
                    string jsonString = ReadFile("practitioner" + (i + 1 + ".json"));
                    if (string.IsNullOrEmpty(jsonString))
                    {
                        json = " Practitioner file not found.";
                    }
                    else
                    {
                        try
                        {
                            JObject apptObj = JObject.Parse(jsonString);

                            FHIRService fHIRService = new FHIRService();
                            JObject jobj = await fHIRService.CreatePractitioner(apptObj);
                            string id = (string)jobj["id"];
                            practitionerList.Add(id);
                            json = JsonConvert.SerializeObject(jobj);
                        } catch (Exception ex)
                        {

                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }


            return json;
        }

        [HttpDelete("RemovePractitioners")]
        public async Task<string> RemovePractitioner()
        {
            string json = "<b>Practitioner with the following ID(s) are deleted: </b>";
            try
            {
                FHIRService fHIRService = new FHIRService();

                JObject jObj = await fHIRService.GetPractitioner();

                List<Appointment> ApptList = new List<Appointment>();

                //          var id = jObj["entry"][0]["resource"]["id"];
                var entry = jObj["entry"];
                var count = entry.Count();

                for (int i = 0; i < count; i++)
                {
                    //  Appointment appt = new Appointment { ID = (string)entry[i]["resource"]["id"] };
                    //  ApptList.Add(appt);
                    string apptID = (string)entry[i]["resource"]["id"];
                    JsonConvert.SerializeObject(await fHIRService.DeletePractitioner(apptID));
                    json = json + " </br> " + apptID;
                }

            }
            catch (Exception ex)
            {

            }


            return json;
        }



        [HttpGet("appointments")]
        public async Task<string> GetAppointments()
        {
            FHIRService fHIRService = new FHIRService();
            string json = JsonConvert.SerializeObject(await fHIRService.GetAppointments());
            return json;
        }



        [HttpPost("CreateAppointments")]
        public async Task<string> Appointments()
        {
            string json = "";
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    string jsonString = ReadFile("appointment"+(i+1+".json"));
                    if (string.IsNullOrEmpty(jsonString))
                    {
                        json = apptFile + " in not found.";
                    }
                    else
                    {
                        JObject apptObj = JObject.Parse(jsonString);
                        try
                        {
                            var patient = apptObj["participant"][0]["actor"]["reference"];
                            var practitioner = apptObj["participant"][1]["actor"]["reference"];
                            apptObj["participant"][0]["actor"]["reference"] = "Patient/" + patientList[i];
                            apptObj["participant"][1]["actor"]["reference"] = "Practitioner/" + practitionerList[i];
                        } catch (Exception ex)
                        {

                        }

                        FHIRService fHIRService = new FHIRService();
                        json = JsonConvert.SerializeObject(await fHIRService.CreateAppointment(apptObj));
                    }
                }

            } catch (Exception ex)
            {

            }
            
            
            return json;
        }


        [HttpDelete("RemoveAppointments")]
        public async Task<string> RemoveAppointments()
        {
            string json = "<b>Appointments with the following ID(s) are deleted: </b>";
            try
            {
                FHIRService fHIRService = new FHIRService();

                JObject jObj = await fHIRService.GetAppointments();

                List<Appointment> ApptList = new List<Appointment>();

     
                var entry = jObj["entry"];
                var count = entry.Count();

                for (int i=0; i < count; i++)
                {
                  
                    string apptID = (string)entry[i]["resource"]["id"];
                    JsonConvert.SerializeObject(await fHIRService.DeleteAppointment(apptID));
                    json = json + " </br> " + apptID;
                }

                







     //           json = JsonConvert.SerializeObject(await fHIRService.DeleteAppointment("82ef6987-c77e-4e26-8559-2b27f73a8ae9"));
                


            }
            catch (Exception ex)
            {

            }


            return json;
        }

        [HttpGet("slots")]
        public async Task<Object> GetSlots()
        {
            FHIRService fHIRService = new FHIRService();





            string json = JsonConvert.SerializeObject(await fHIRService.GetSlots());
            return json;
        }


        [HttpPost("CreateSlots")]
        public async Task<string> Slots()
        {
            string json = "";
            try
            {
                scheduleList = new ArrayList();
                for (int i = 0; i < 5; i++)
                {
                 //   scheduleList.Add("" + i);
                    string jsonString = ReadFile("slot" + (1 + ".json"));
                    if (string.IsNullOrEmpty(jsonString))
                    {
                        json = "Slot file not found.";
                    }
                    else
                    {
                        JObject apptObj = JObject.Parse(jsonString);
                        try
                        {

                            var schedule = apptObj["schedule"]["reference"];


                            apptObj["schedule"]["reference"] = "Schedule/" + scheduleList[i];
                        }
                        catch (Exception ex)
                        {

                        }

                        FHIRService fHIRService = new FHIRService();
                        JObject jobj = await fHIRService.CreateSlot(apptObj);
            //            string id = (string)jobj["id"];
            //            patientList.Add(id);
                        json = JsonConvert.SerializeObject(jobj);
                    }
                }

            }
            catch (Exception ex)
            {

            }


            return json;
        }

        [HttpDelete("RemoveSlots")]
        public async Task<string> RemoveSlots()
        {
            string json = "<b>Slots with the following ID(s) are deleted: </b>";
            try
            {
                FHIRService fHIRService = new FHIRService();

                JObject jObj = await fHIRService.GetSlots();

               

                var entry = jObj["entry"];
                var count = entry.Count();

                for (int i = 0; i < count; i++)
                {

                    string apptID = (string)entry[i]["resource"]["id"];
                    JsonConvert.SerializeObject(await fHIRService.DeleteSlot(apptID));
                    json = json + " </br> " + apptID;
                }

            }
            catch (Exception ex)
            {

            }


            return json;
        }

        [HttpGet("schedules")]
        public async Task<Object> GetSchedules()
        {
            FHIRService fHIRService = new FHIRService();





            string json = JsonConvert.SerializeObject(await fHIRService.GetSchedules());
            return json;
        }


        [HttpPost("CreateSchedules")]
        public async Task<string> Schedules()
        {
            string json = "";
            try
            {
             //   practitionerList = new ArrayList();

                scheduleList = new ArrayList();
                for (int i = 0; i < 5; i++)
                {
                 //   practitionerList.Add("" + i);
                    string jsonString = ReadFile("schedule" + (1+ ".json"));
                    if (string.IsNullOrEmpty(jsonString))
                    {
                        json = "Schedule file not found.";
                    }
                    else
                    {
                        JObject apptObj = JObject.Parse(jsonString);
                        try
                        {

                            var practitioner = apptObj["actor"][0]["reference"];


                            apptObj["actor"][0]["reference"] = "Practitioner/" + practitionerList[i];
                        }
                        catch (Exception ex)
                        {

                        }


                        FHIRService fHIRService = new FHIRService();
                        JObject jobj = await fHIRService.CreateSchedule(apptObj);
                        string id = (string)jobj["id"];
                        scheduleList.Add(id);
                        json = JsonConvert.SerializeObject(jobj);
                    }
                }

            }
            catch (Exception ex)
            {

            }


            return json;
        }

        [HttpDelete("RemoveSchedules")]
        public async Task<string> RemoveSchedules()
        {
            string json = "<b>Schedules with the following ID(s) are deleted: </b>";
            try
            {
                FHIRService fHIRService = new FHIRService();

                JObject jObj = await fHIRService.GetSchedules();

               

                var entry = jObj["entry"];
                var count = entry.Count();

                for (int i = 0; i < count; i++)
                {

                    string apptID = (string)entry[i]["resource"]["id"];
                    JsonConvert.SerializeObject(await fHIRService.DeleteSchedule(apptID));
                    json = json + " </br> " + apptID;
                }

            }
            catch (Exception ex)
            {

            }


            return json;
        }

        private string ReadFile(string filename)
        {
            string json = null;
            string path = Path.Combine(_env.WebRootPath, filename);
             if (System.IO.File.Exists(path))
                {
                    json = System.IO.File.ReadAllText(path);
                }
            
            return json;
        }
    }
}
