using API.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class CheckDigitController : BaseAPIController
    {
        private readonly ICheckDigitRepository _checkDigitRepository;

        public CheckDigitController(ICheckDigitRepository checkDigitRepository)
        {
            _checkDigitRepository = checkDigitRepository;
        }


        [HttpGet("{trackingNumber}")]
        public int GetCheckDigit(long trackingNumber)
        {
            return _checkDigitRepository.calculateCheckDigit(trackingNumber);
        }


    }
}
