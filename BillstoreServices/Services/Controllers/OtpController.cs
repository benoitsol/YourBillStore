using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Services.BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Controllers
{
    [Produces("application/json")]
    [Route("api/oneTimePassword")]
    public class OtpController
    {
        private readonly OTPService otpService;

        public OtpController(IConfiguration configuration)
        {
            otpService = new OTPService(configuration);
        }

        [HttpPut]
        public async Task<bool> requestOtp(string phoneNumber)
        {
            return await otpService.RequestOtp(phoneNumber);
        }

        [HttpPut]
        public async Task<bool> validateOnetimePassword(string phoneNumber, string onetimePassword)
        {
            return await otpService.validateUser(phoneNumber, onetimePassword);
        }

    }
}
