using AutoMapper;
using Contracts;
using Entites;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineAPI.Presentation.Controllers
{
    [Route("api/Payment/[action]")]

    [ApiController]
    public class PaymentController : ControllerBase
    {

        private readonly IRepositoryManegar _repository;
        private readonly IMapper _mapper;

        public PaymentController(IRepositoryManegar repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetPayments")]
        public ActionResult GetPayments()
        {
            try
            {

                var payments = _repository.Payment.GetAllPayments();

                var paymentDtos = _mapper.Map<IEnumerable<PaymentDto>>(payments);

                if (paymentDtos == null)
                {
                    return StatusCode(404, "Empty");
                }
                else
                {
                    return Ok(paymentDtos);
                }
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("{id:int}", Name = "GetPayment")]
        public IActionResult GetPayment(int id)
        {
            try
            {

                var payment = _repository.Payment.GetPaymentById(id);

                var paymentDTO = _mapper.Map<PaymentDto>(payment);

                if (paymentDTO == null)
                {
                    return StatusCode(404, "Empty");
                }
                else
                {
                    return Ok(paymentDTO);
                }

            }
            catch
            {
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpPost(Name = "createPayment")]
        public ActionResult createPayment(PaymentDto payment)
        {
            ArgumentNullException.ThrowIfNull(payment);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var paymentEntity = _mapper.Map<Payment>(payment);
            _repository.Payment.CreatePayment(paymentEntity);

            _repository.Save();
            var ReturnedPayment = _mapper.Map<PaymentDto>(payment);
            return CreatedAtRoute("GetPayment", new { Id = ReturnedPayment.id }, ReturnedPayment);

        }

        [HttpPut("{Id:int}", Name = "UpdatePayment")]
        public IActionResult UpdatePayment([FromBody] PaymentUpdateDto payment, int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest($"payment with id  {Id}  already has deleted");
            }
            else
            {
                var SelectedPayment = _repository.Payment.GetPaymentById(Id);
                ArgumentNullException.ThrowIfNull(SelectedPayment);
                var paymentEntity = _mapper.Map(payment, SelectedPayment);
                _repository.Payment.UpdatePayment(paymentEntity);
                _repository.Save();
                return Ok($"the Payment with id {Id} has been updeted successfully");
            }
        }

        [HttpDelete("{Id:int}", Name ="DeletePayment")]
        public IActionResult DeletePayment(int Id) 
        {
            var payment = _repository.Payment.GetPaymentById(Id);
            ArgumentNullException.ThrowIfNull(payment);

            _repository.Payment.DeletePayment(payment);
            _repository.Save();
            return Ok($"payment with id {Id} deleted");
        }

    }
}
