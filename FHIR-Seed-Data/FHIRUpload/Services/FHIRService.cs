using FHIRUpload.Services.Authentication;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FHIRUpload.Services
{
    public class FHIRService : BaseFHIRService
    {






        public async Task<JObject> GetPatients()
        {
            string urlExt = "/Patient";
            JObject json = await RunAsync(urlExt, HttpMethodType.Get, null);
            return json;
        }

        public async Task<JObject> CreatePatient(JObject obj)
        {
            string urlExt = "/Patient";
            var output = JsonConvert.SerializeObject(obj);
            var data = new StringContent(output, Encoding.UTF8, "application/json");

            JObject json = await RunAsync(urlExt, HttpMethodType.Post, data);
            return json;

        }

        public async Task<JObject> DeletePatient(string id)
        {
            string urlExt = "/Patient";


            JObject json = await RunAsync(urlExt + "/" + id, HttpMethodType.Delete, null);
            return json;

        }

        public async Task<JObject> GetPractitioner()
        {
            string urlExt = "/Practitioner";
            JObject json = await RunAsync(urlExt, HttpMethodType.Get, null);
            return json;
        }

        public async Task<JObject> CreatePractitioner(JObject obj)
        {
            string urlExt = "/Practitioner";
            var output = JsonConvert.SerializeObject(obj);
            var data = new StringContent(output, Encoding.UTF8, "application/json");

            JObject json = await RunAsync(urlExt, HttpMethodType.Post, data);
            return json;

        }

        public async Task<JObject> DeletePractitioner(string id)
        {
            string urlExt = "/Practitioner";


            JObject json = await RunAsync(urlExt + "/" + id, HttpMethodType.Delete, null);
            return json;

        }


        public async Task<JObject> GetAppointments()
        {
            string urlExt = "/Appointment";
            JObject json = await RunAsync(urlExt, HttpMethodType.Get, null);
     
            return json;
        }

        public async Task<JObject> CreateAppointment(JObject obj)
        {
            string urlExt = "/Appointment";
            var output = JsonConvert.SerializeObject(obj);
            var data = new StringContent(output, Encoding.UTF8, "application/json");
            
            JObject json = await RunAsync(urlExt, HttpMethodType.Post, data);
            return json;

        }

        public async Task<JObject> DeleteAppointment(string id)
        {
            string urlExt = "/Appointment";
           

            JObject json = await RunAsync(urlExt+"/"+id, HttpMethodType.Delete, null);
            return json;

        }

        public async Task<JObject> GetSlots()
        {
            string urlExt = "/Slot";
            JObject json = await RunAsync(urlExt, HttpMethodType.Get, null);

            return json;
        }

        public async Task<JObject> CreateSlot(JObject obj)
        {
            string urlExt = "/Slot";
            var output = JsonConvert.SerializeObject(obj);
            var data = new StringContent(output, Encoding.UTF8, "application/json");

            JObject json = await RunAsync(urlExt, HttpMethodType.Post, data);
            return json;

        }

        public async Task<JObject> DeleteSlot(string id)
        {
            string urlExt = "/Slot";


            JObject json = await RunAsync(urlExt + "/" + id, HttpMethodType.Delete, null);
            return json;

        }

        public async Task<JObject> GetSchedules()
        {
            string urlExt = "/Schedule";
            JObject json = await RunAsync(urlExt, HttpMethodType.Get, null);

            return json;
        }

        public async Task<JObject> CreateSchedule(JObject obj)
        {
            string urlExt = "/Schedule";
            var output = JsonConvert.SerializeObject(obj);
            var data = new StringContent(output, Encoding.UTF8, "application/json");

            JObject json = await RunAsync(urlExt, HttpMethodType.Post, data);
            return json;

        }

        public async Task<JObject> DeleteSchedule(string id)
        {
            string urlExt = "/Schedule";


            JObject json = await RunAsync(urlExt + "/" + id, HttpMethodType.Delete, null);
            return json;

        }
    }
}
