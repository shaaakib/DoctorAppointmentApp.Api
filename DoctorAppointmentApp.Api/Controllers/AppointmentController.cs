using DoctorAppointmentApp.Api.Data;
using DoctorAppointmentApp.Api.Models;
using DoctorAppointmentApp.Api.Models.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowCors")]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentDbContext _db;

        public AppointmentController(AppointmentDbContext db)
        {
            _db = db;
        }

        [Route("getAllAppointment")]
        [HttpGet]
        public IActionResult GetAllAppointment()
        {
            var result = (from app in _db.Appointments
                          join Patient in _db.Patients on app.patientId equals Patient.patientId
                          select new
                          {
                              patientName = Patient.patientName,
                              email = Patient.email,
                              city = Patient.city,
                              appointmentId = app.appointmentId,
                              appointmentDate = app.appointmentDate,
                              isDone = app.isDone
                          }).ToList();

            return Ok(result);
        }

        [Route("getNewAppointment")]
        [HttpGet]
        public IActionResult getNewAppointment()
        {
            var result = (from app in _db.Appointments
                          where app.isDone == false
                          join Patient in _db.Patients on app.patientId equals Patient.patientId
                          select new
                          {
                              patientName = Patient.patientName,
                              email = Patient.email,
                              city = Patient.city,
                              appointmentId = app.appointmentId,
                              appointmentDate = app.appointmentDate,
                              isDone = app.isDone
                          }).ToList();

            return Ok(result);
        }

        [Route("getDoneAppointment")]
        [HttpGet]
        public IActionResult getDoneAppointment()
        {
            var result = (from app in _db.Appointments
                          where app.isDone == true
                          join Patient in _db.Patients on app.patientId equals Patient.patientId
                          select new
                          {
                              patientName = Patient.patientName,
                              email = Patient.email,
                              city = Patient.city,
                              appointmentId = app.appointmentId,
                              appointmentDate = app.appointmentDate,
                              isDone = app.isDone
                          }).ToList();

            return Ok(result);
        }

        [Route("ChangeStatus")]
        [HttpGet]
        public IActionResult ChangeStatus(int appointmentid)
        {
            var data = _db.Appointments.SingleOrDefault(x => x.appointmentId == appointmentid);
            data.isDone = true;

            _db.SaveChanges();
            return Ok(data);
        }

        [Route("createNewAppointement")]
        [HttpPost]
        public IActionResult createNewAppointement(NewAppointmentDto obj)
        {
            var isPatientExist = _db.Patients.SingleOrDefault(x => x.mobileNo == obj.mobileNo);
            if (isPatientExist == null)
            {
                Patient _newPat = new Patient()
                {
                    patientName = obj.patientName,
                    email = obj.email,
                    city = obj.city,
                    mobileNo = obj.mobileNo,
                    address = obj.address
                };
                _db.Patients.Add(_newPat);
                _db.SaveChanges();

                Appointment _newApp = new Appointment()
                {
                    patientId = _newPat.patientId,
                    appointmentDate = obj.appointmentDate,
                    isDone = false
                };

                _db.Appointments.Add(_newApp);
                _db.SaveChanges();
            }
            else
            {
                Appointment _newApp = new Appointment()
                {
                    patientId = isPatientExist.patientId,
                    appointmentDate = obj.appointmentDate,
                    isDone = false
                };

                _db.Appointments.Add(_newApp);
                _db.SaveChanges();
            }

            return Ok("Appointment Created");

        }

    }
}
